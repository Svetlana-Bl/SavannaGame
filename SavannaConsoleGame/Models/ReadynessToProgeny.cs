using SavannaConsoleGame.SavannaLogic;

namespace SavannaConsoleGame
{
    public struct Progeny
    {
        public Animal parent;
        public int IterationCount { get; set; }
        public bool NearOrNot;
    }
}