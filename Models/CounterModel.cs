using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace IconCps.Blazor.Models
{
    public class CounterModel : ModelBase<CounterModel>
    {
        private int _currentCount;

        private readonly ObservableAsPropertyHelper<int> _count;

        public CounterModel()
        {
            Increment = ReactiveCommand.CreateFromTask(IncrementCount);

            _count = Increment.ToProperty(this, x => x.CurrentCount);
        }

        public int CurrentCount => _count.Value;

        public ReactiveCommand<Unit, int> Increment { get; }

        private Task<int> IncrementCount()
        {
            _currentCount++;
            return Task.FromResult(_currentCount);
        }
    }
}