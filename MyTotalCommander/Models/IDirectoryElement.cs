namespace MyTotalCommander.Models
{
    public interface IDirectoryElement
    {
        /// <summary>
        /// Gets the name of the directory element.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets the full path of the directory element.
        /// </summary>
        string FullPath { get; }
        /// <summary>
        /// Gets a value indicating whether this element is hidden.
        /// </summary>
        bool IsHidden { get; }
    }
}