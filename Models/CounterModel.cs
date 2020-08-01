using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace IconCps.Blazor.Models
{
    public class CounterModel : ModelBase<CounterModel>
    {
        public int CurrentCount { get; set; }

        public ReactiveCommand<Unit, Unit> Increment { get; }

        public CounterModel()
        {
            Increment = ReactiveCommand.CreateFromTask(() =>
            {
                CurrentCount++;
                return Task.CompletedTask;
            });
        }
    }
}