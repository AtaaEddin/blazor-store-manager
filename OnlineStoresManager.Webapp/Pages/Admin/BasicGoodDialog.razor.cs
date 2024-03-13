using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;
using OnlineStoresManager.Identity;
using OnlineStoresManager.WebApp.Components.Dialog;
using OnlineStoresManager.WebApp.Services;
using OnlineStoresManager.WebApp.Services.Goods;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Pages.Admin
{
    public partial class BasicGoodDialog : OSMAwaitableComponent
    {
        [CascadingParameter]
        MudDialogInstance? MudDialog { get; set; }

        [Parameter]
        public GoodType? Type { get; set; }

        [Parameter]
        public BasicGood? BasicGood { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

        [Parameter]
        public EventCallback<BasicGood> OnSaved { get; set; }

        [Inject]
        public GoodValidationBuilder GoodValidationBuilder { get; set; } = null!;

        [Inject]
        public GoodService GoodService { get; set; } = null!;

        [Inject]
        public ImageService ImageService { get; set; } = null!;

        private const string DefaultDragClass = "relative rounded-lg border-2 border-dashed pa-4 mt-4 mud-width-full mud-height-full z-10";
        private string _dragClass = DefaultDragClass;
        protected IMudValidation? GoodValidation { get; set; }
        protected DialogOptions? DialogOptions { get; set; }
        protected bool IsNew => BasicGood?.Id == null || BasicGood?.Id == Guid.Empty;
        protected MudForm? MudFormRef { get; set; }
        protected MudSelect<string>? ShirtTypeSelectRef { get; set; }
        protected IReadOnlyList<IBrowserFile>? Files { get; set; }

        
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Load();
        }

        protected void Close()
        {
            OSMDialogService.Close();
            MudDialog?.Cancel();
        }

        private void Load()
        {
            BasicGood ??= GoodBuilder.Create(Type ?? GoodType.Shirt);
            GoodValidation = GoodValidationBuilder.Create(BasicGood);
        }

        protected async Task Save()
        {
            await MudFormRef!.Validate();

            if (MudFormRef.IsValid)
            {
                var imagesPaths = await UploadImages() ?? new List<string>();
                BasicGood!.ImageUrls ??= new List<string>();
                BasicGood!.ImageUrls.AddRange(imagesPaths);

                BasicGood? saved = IsNew
                    ? await GoodService.Create(BasicGood!)
                    : await GoodService.Update(BasicGood!);

                await OnSaved.InvokeAsync(saved);
                MudDialog!.Close();
            }
        }

        protected Task TypeChanged(string goodTypeStr)
        {
            return Await(async () =>
            {
                BasicGood.Type = Enum.Parse<GoodType>(goodTypeStr);
                await OSMDialogService.Close();
                MudDialog!.Close();
                await OSMDialogService.Show<BasicGoodDialog>(
                    new Dictionary<string, object>
                    {
                        [nameof(Goods.BasicGood.Type)] = BasicGood.Type,
                        [nameof(BasicGoodDialog.OnSaved)] = EventCallback.Factory.Create<BasicGood>(this, OnSaved)
                    });
            });
        }

        private async Task<IReadOnlyCollection<string>?> UploadImages()
        {
            if (Files == null) { return default; }
            List<Image> images = new List<Image>();
            using var memoryStream = new MemoryStream();
            foreach(var file in Files)
            {
                await file.OpenReadStream().CopyToAsync(memoryStream);
                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                images.Add(new Image
                { 
                    Data = memoryStream.ToArray(),
                    Metadata = new ImageMetadata
                    {
                        Format = Path.GetExtension(file.Name),
                        UserName = authState!.User.FindFirst(Claims.UniqueName)?.Value ?? string.Empty,
                        CreatedAt = DateTime.Now,
                        Gategory = BasicGood!.Gategory!.Value,
                        Type = BasicGood.Type!.Value
                    }
                });
                memoryStream.SetLength(0);
            }
                
            if(images.Count == 0) { return default; }
            List<string> imagesPaths = new List<string>();
            foreach(var image in images)
            {
                var imageFullPath = await ImageService.Upload(image);
                if (imageFullPath == null)
                {
                    throw new Exception("return image path cannot be null");
                }
                imagesPaths.Add(imageFullPath);
            }
            return imagesPaths.AsReadOnly();
        }

        private void SetDragClass()
            => _dragClass = $"{DefaultDragClass} mud-border-primary";

        private void ClearDragClass()
            => _dragClass = DefaultDragClass;

    }
}
