namespace KHSave.Attributes
{
    public class MateriaAttribute : MagicAttribute
    {
        public MateriaAttribute(string name = null) :
            base(name)
        {

        }
    }

    public class MagicMateriaAttribute : MateriaAttribute
    {
        public MagicMateriaAttribute(string name = null) :
            base(name)
        {

        }
    }

    public class CommandMateriaAttribute : MateriaAttribute
    {
        public CommandMateriaAttribute(string name = null) :
            base(name)
        {

        }
    }

    public class SupportMateriaAttribute : MateriaAttribute
    {
        public SupportMateriaAttribute(string name = null) :
            base(name)
        {

        }
    }

    public class CompleteMateriaAttribute : MateriaAttribute
    {
        public CompleteMateriaAttribute(string name = null) :
            base(name)
        {

        }
    }

    public class SummonMateriaAttribute : MateriaAttribute
    {
        public SummonMateriaAttribute(string name = null) :
            base(name)
        {

        }
    }
}
