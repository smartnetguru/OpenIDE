namespace OpenIDE.Core.JSON.Framework
{
    public delegate Result<TInput, TValue> Parser<TInput, TValue>(TInput input);
}