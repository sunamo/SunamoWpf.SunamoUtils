namespace SunamoWpf._sunamo;

public interface ISelectFromMany<Data>
{
    void AddControl(Data data, bool value);
    void AddControls();
}