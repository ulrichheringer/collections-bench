using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CollectionsBench.Benchmark;

namespace CollectionsBench.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<BenchmarkRow> Results { get; } = [];
    [ObservableProperty] private string _summary = "O mesmo conjunto de dados fixo é usado em cada execução; os tempos variam conforme a máquina.";

    [RelayCommand]
    private void RunBenchmarks()
    {
        Results.Clear();
        foreach (var result in CollectionBenchmarks.Run()) Results.Add(result);
        Summary = "15.000 itens · 1.500 consultas (metade existentes) · mediana de 5 repetições · semente 180.";
    }
}
