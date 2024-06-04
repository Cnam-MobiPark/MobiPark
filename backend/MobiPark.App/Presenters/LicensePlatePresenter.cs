namespace MobiPark.App.Presenters;

public enum LicensePlateType
{
    FR,
    DE
}

public class LicensePlatePresenter
{
    public LicensePlateType type { get; set; }
    public string value { get; set; }
}