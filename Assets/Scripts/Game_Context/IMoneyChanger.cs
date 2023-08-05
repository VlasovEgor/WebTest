public interface IMoneyChanger
{
    void ChangeLoadTimeMultiplier(int timeMultiplier);
    void ChangeMoney();
    void ChangeUnloadTimeMultiplier(int timeMultiplier);
    void GotUpOnPlatform(PlatformStatus platformStatus);
    void LeftPlatform();
}