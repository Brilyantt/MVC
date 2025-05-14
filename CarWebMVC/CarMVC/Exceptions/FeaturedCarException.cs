namespace CarMVC.Exceptions;

public class FeaturedCarException : Exception
{
    public FeaturedCarException() : base("Deafult Exception message") 
    {
        
    }
    public FeaturedCarException(string errorMessage) : base(errorMessage)
    { 

    }
   
}
