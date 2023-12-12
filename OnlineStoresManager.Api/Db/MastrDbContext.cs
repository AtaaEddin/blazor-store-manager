using Microsoft.EntityFrameworkCore;

namespace OnlineStoresManager.API
{
    public class MastrDbContext : DbContext
    {
        public MastrDbContext(DbContextOptions<MastrDbContext> options)
            : base(options) { }
        public DbSet<MastrAsset> MastrAssets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MastrAsset>(asset =>
            {
                asset.ToTable("EinheitenWind");
                asset.HasKey(a => a.Id);

                asset.Property(a => a.Id)
                     .HasColumnName("EinheitMastrNummer")
                     .HasMaxLength(MastrAsset.IdMaxLength);

                asset.Property(a => a.Bruttoleistung)
                     .HasColumnName("Bruttoleistung");

                asset.Property(a => a.DatumLetzteAktualisierung)
                     .HasColumnName("DatumLetzteAktualisierung");

                asset.Property(a => a.EinheitBetriebsstatus)
                     .HasColumnName("EinheitBetriebsstatus");

                asset.Property(a => a.EinheitSystemstatus)
                     .HasColumnName("EinheitSystemstatus");

                asset.Property(a => a.Energietraeger)
                     .HasColumnName("Energietraeger");

                asset.Property(a => a.KraftwerksnummerNv)
                     .HasColumnName("Kraftwerksnummer_nv");

                asset.Property(a => a.Lage)
                     .HasColumnName("Lage");

                asset.Property(a => a.Land)
                     .HasColumnName("Land");

                asset.Property(a => a.NameStromerzeugungseinheit)
                     .HasColumnName("NameStromerzeugungseinheit")
                     .HasMaxLength(MastrAsset.NameStromerzeugungseinheitMaxLength);

                asset.Property(a => a.Nettonennleistung)
                     .HasColumnName("Nettonennleistung");

                asset.Property(a => a.NetzbetreiberpruefungStatus)
                     .HasColumnName("NetzbetreiberpruefungStatus");

                asset.Property(a => a.NichtVorhandenInMigriertenEinheiten)
                     .HasColumnName("NichtVorhandenInMigriertenEinheiten");

                asset.Property(a => a.Registrierungsdatum)
                     .HasColumnName("Registrierungsdatum");

                asset.Property(a => a.Technologie)
                     .HasColumnName("Technologie");

                asset.Property(a => a.WeicNv)
                     .HasColumnName("Weic_nv");

                asset.Property(a => a.Rotordurchmesser)
                     .HasColumnName("Rotordurchmesser");

                asset.Property(a => a.LokationMaStRNummer)
                     .HasColumnName("LokationMaStRNummer")
                     .HasMaxLength(MastrAsset.LokationMaStRNummerMaxLength);

                asset.Property(a => a.Postleitzahl)
                     .HasColumnName("Postleitzahl");

                asset.Property(a => a.HausnummerNichtGefunden)
                     .HasColumnName("HausnummerNichtGefunden");

                asset.Property(a => a.Landkreis)
                     .HasColumnName("Landkreis")
                     .HasMaxLength(MastrAsset.LandkreisMaxLength);

                asset.Property(a => a.StrasseNichtGefunden)
                     .HasColumnName("StrasseNichtGefunden");

                asset.Property(a => a.Typenbezeichnung)
                     .HasColumnName("Typenbezeichnung")
                     .HasMaxLength(MastrAsset.TypenbezeichnungMaxLength);

                asset.Property(a => a.NetzbetreiberpruefungDatum)
                     .HasColumnName("NetzbetreiberpruefungDatum");

                asset.Property(a => a.Ort)
                     .HasColumnName("Ort")
                     .HasMaxLength(MastrAsset.OrtMaxLength);

                asset.Property(a => a.Nabenhoehe)
                     .HasColumnName("Nabenhoehe");

                asset.Property(a => a.Laengengrad)
                     .HasColumnName("Laengengrad");

                asset.Property(a => a.Inbetriebnahmedatum)
                     .HasColumnName("Inbetriebnahmedatum");

                asset.Property(a => a.Hersteller)
                     .HasColumnName("Hersteller");

                asset.Property(a => a.HausnummerNv)
                     .HasColumnName("Hausnummer_nv");

                asset.Property(a => a.Gemeinde)
                     .HasColumnName("Gemeinde")
                     .HasMaxLength(MastrAsset.GemeindeMaxLength);

                asset.Property(a => a.Gemeindeschluessel)
                     .HasColumnName("Gemeindeschluessel");

                asset.Property(a => a.GenMastrNummer)
                     .HasColumnName("GenMastrNummer")
                     .HasMaxLength(MastrAsset.GenMastrNummerMaxLength);

                asset.Property(a => a.Gemarkung)
                     .HasColumnName("Gemarkung")
                     .HasMaxLength(MastrAsset.GemarkungMaxLength);

                asset.Property(a => a.Strasse)
                     .HasColumnName("Strasse")
                     .HasMaxLength(MastrAsset.StrasseMaxLength);

                asset.Property(a => a.Rotorblattenteisungssystem)
                     .HasColumnName("Rotorblattenteisungssystem");

                asset.Property(a => a.FlurFlurstuecknummern)
                     .HasColumnName("FlurFlurstuecknummern")
                     .HasMaxLength(MastrAsset.FlurFlurstuecknummernMaxLength);

                asset.Property(a => a.FernsteuerbarkeitNb)
                     .HasColumnName("FernsteuerbarkeitNb");

                asset.Property(a => a.FernsteuerbarkeitDr)
                     .HasColumnName("FernsteuerbarkeitDr");

                asset.Property(a => a.FernsteuerbarkeitDv)
                     .HasColumnName("FernsteuerbarkeitDv");

                asset.Property(a => a.Einspeisungsart)
                     .HasColumnName("Einspeisungsart");

                asset.Property(a => a.EegMaStRNummer)
                     .HasColumnName("EegMaStRNummer")
                     .HasMaxLength(MastrAsset.EegMaStRNummerMaxLength);

                asset.Property(a => a.Bundesland)
                     .HasColumnName("Bundesland");

                asset.Property(a => a.Breitengrad)
                     .HasColumnName("Breitengrad");

                asset.Property(a => a.AuflagenAbschaltungSchattenwurf)
                     .HasColumnName("AuflagenAbschaltungSchattenwurf");

                asset.Property(a => a.AnschlussAnHoechstOderHochSpannung)
                     .HasColumnName("AnschlussAnHoechstOderHochSpannung");

                asset.Property(a => a.AuflageAbschaltungLeistungsbegrenzung)
                     .HasColumnName("AuflageAbschaltungLeistungsbegrenzung");

                asset.Property(a => a.AuflagenAbschaltungSonstige)
                     .HasColumnName("AuflagenAbschaltungSonstige");

                asset.Property(a => a.AnlagenbetreiberMastrNummer)
                     .HasColumnName("AnlagenbetreiberMastrNummer")
                     .HasMaxLength(MastrAsset.AnlagenbetreiberMastrNummerMaxLength);

                asset.Property(a => a.AuflagenAbschaltungTierschutz)
                     .HasColumnName("AuflagenAbschaltungTierschutz");

                asset.Property(a => a.AuflagenAbschaltungSchallimmissionsschutzNachts)
                     .HasColumnName("AuflagenAbschaltungSchallimmissionsschutzNachts");

                asset.Property(a => a.Adresszusatz)
                     .HasColumnName("Adresszusatz")
                     .HasMaxLength(MastrAsset.AdresszusatzMaxLength);

                asset.Property(a => a.AuflagenAbschaltungEiswurf)
                     .HasColumnName("AuflagenAbschaltungEiswurf");

                asset.Property(a => a.ClusterOstsee)
                     .HasColumnName("ClusterOstsee");

                asset.Property(a => a.AuflagenAbschaltungSchallimmissionsschutzTagsueber)
                     .HasColumnName("AuflagenAbschaltungSchallimmissionsschutzTagsueber");

                asset.Property(a => a.DatumBeginnVoruebergehendeStilllegung)
                     .HasColumnName("DatumBeginnVoruebergehendeStilllegung");

                asset.Property(a => a.GeplantesInbetriebnahmedatum)
                     .HasColumnName("GeplantesInbetriebnahmedatum");

                asset.Property(a => a.ClusterNordsee)
                     .HasColumnName("ClusterNordsee");

                asset.Property(a => a.DatumDesBetreiberwechsels)
                     .HasColumnName("DatumDesBetreiberwechsels");

                asset.Property(a => a.DatumEndgueltigeStilllegung)
                     .HasColumnName("DatumEndgueltigeStilllegung");

                asset.Property(a => a.Hausnummer)
                     .HasColumnName("Hausnummer")
                     .HasMaxLength(MastrAsset.HausnummerMaxLength);

                asset.Property(a => a.Kuestenentfernung)
                     .HasColumnName("Kuestenentfernung");

                asset.Property(a => a.DatumRegistrierungDesBetreiberwechsels)
                     .HasColumnName("DatumRegistrierungDesBetreiberwechsels");

                asset.Property(a => a.Kraftwerksnummer)
                     .HasColumnName("Kraftwerksnummer")
                     .HasMaxLength(MastrAsset.KraftwerksnummerMaxLength);

                asset.Property(a => a.DatumWiederaufnahmeBetrieb)
                     .HasColumnName("DatumWiederaufnahmeBetrieb");

                asset.Property(a => a.Seelage)
                     .HasColumnName("Seelage");

                asset.Property(a => a.Weic)
                     .HasColumnName("Weic")
                     .HasMaxLength(MastrAsset.WeicMaxLength);

                asset.Property(a => a.Wassertiefe)
                     .HasColumnName("Wassertiefe");

                asset.Property(a => a.WeicDisplayName)
                     .HasColumnName("WeicDisplayName")
                     .HasMaxLength(MastrAsset.WeicDisplayNameMaxLength);

                asset.Property(a => a.CrmGuid)
                     .HasColumnName("Crm_Guid");
            });
        }
    }
}
