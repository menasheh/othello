namespace GameFramework
{
    public interface IPlay<in T> where T : Playable
    {
        (int x, int y) Move(T game);
    }
}