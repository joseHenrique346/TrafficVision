using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Domain.Entities;

public sealed class VehicleOwner
{
    #region Properties
    public string Name { get; private set; }
    public string CpfCnpj { get; private set; }
    public string Cnh { get; private set; }
    #endregion

    #region Constructors
    public VehicleOwner() { }

    public VehicleOwner(string name, string cpfCnpj, string cnh)
    {
        BaseValidate.NullOrWhiteSpace(name, $"{Name}");
        BaseValidate.NullOrWhiteSpace(cpfCnpj, $"{CpfCnpj}");
        BaseValidate.NullOrWhiteSpace(cnh, $"{Cnh}");

        Name = name;
        CpfCnpj = cpfCnpj;
        Cnh = cnh;
    }
    #endregion

    #region Create/Update
    public static VehicleOwner Create(string name, string cpfCnpj, string cnh)
    {
        return new VehicleOwner(name, cpfCnpj, cnh);
    }

    public void Update(string name, string cpfCnpj, string cnh)
    {
        BaseValidate.NullOrWhiteSpace(name, $"{Name}");
        BaseValidate.NullOrWhiteSpace(cpfCnpj, $"{CpfCnpj}");
        BaseValidate.NullOrWhiteSpace(cnh, $"{Cnh}");

        Name = name;
        CpfCnpj = cpfCnpj;
        Cnh = cnh;
    }
    #endregion
}
