namespace Blog.ViewModels
{
    public class ResultViewModels<T>
    {
        public ResultViewModels(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }
        public ResultViewModels(T data)
        {
            Data = data;
        }
        public ResultViewModels(List<string> errors)
        {
            Errors = errors;
        }
        public ResultViewModels(string error)
        {
            Errors.Add(error);
        }
        public T Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
    }
}