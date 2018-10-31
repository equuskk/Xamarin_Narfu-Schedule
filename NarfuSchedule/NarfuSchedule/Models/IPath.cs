namespace NarfuSchedule.Models
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}