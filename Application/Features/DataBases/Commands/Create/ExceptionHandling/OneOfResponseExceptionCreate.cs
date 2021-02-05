using System;

namespace Application.Features.DataBases.Commands.Create.ExceptionHandling
{
    //public class OneOfResponse<T>
    //{
    //    public object ResponseApiObject { get; set; }
    //    public readonly T Type;
    //    public OneOfResponse(T Type)

    //    {
    //        this.Type = Type;
    //    }

    //    public OneOfResponse(T Type, object value)

    //    {
    //        this.Type = Type;
    //        this.ResponseApiObject = value;

    //    }

    //}

    //public class ResponeCustom
    //{
    //    public readonly string message;
    //    public ResponeCustom(OneOfResponseCreate.SuceesType Type, object result)
    //    {
    //        new OneOfResponseCreate(Type, result);

    //    }

    //}

    //public class OneOfResponseCreate : OneOfResponse<OneOfResponseCreate.SuceesType>
    //{
    //    public enum SuceesType
    //    {
    //        CreateDataBesesCommand
    //    }



    //    public OneOfResponseCreate(SuceesType Type) : base(Type) { }
    //    public OneOfResponseCreate(SuceesType Type, object value) : base(Type, value) { }


    //}



    public class OneOfResponseExceptionCreate : Exception
    {
        public object ResponseApiObject { get; set; }
        public bool succes { get; set; }
        public enum ExceptionType
        {
            ExceptionDataBaseAlreadyExists
           , ExceptionValidation
        }

        public enum SuceesType
        {
            CreateDataBesesCommand
        }

        public readonly object Type;
        public OneOfResponseExceptionCreate(ExceptionType Type, string message, object value)
           : base(message)
        {
            this.Type = Type;
            this.ResponseApiObject = value;
            this.succes = false;
        }
        public OneOfResponseExceptionCreate(SuceesType Type, object value)

        {
            this.Type = Type;
            this.ResponseApiObject = value;
            this.succes = true;

        }
    }

    public class ExceptionCustom
    {
        public readonly string message;
        public ExceptionCustom(OneOfResponseExceptionCreate.ExceptionType Type, object result)
        {
            throw new OneOfResponseExceptionCreate(Type, "valeur existe deja", result);

            //ExecuteException(Type, OneOfCreateDataBaseResponse);
        }

        public ExceptionCustom(OneOfResponseExceptionCreate.SuceesType Type, object result)
        {
            throw new OneOfResponseExceptionCreate(Type, result);

            //ExecuteException(Type, OneOfCreateDataBaseResponse);
        }
        //public void ExecuteException(CustomException.ExceptionType Type, object OneOfCreateDataBaseResponse)
        //{
        //    switch (Type)
        //    {
        //        case CustomException.ExceptionType.ExisteDejaException:
        //            throw new CustomException(CustomException.ExceptionType.ExisteDejaException, "valeur existe deja", OneOfCreateDataBaseResponse);

        //        case CustomException.ExceptionType.validationException:
        //            Console.WriteLine("Case 2");
        //            break;
        //        default:
        //            Console.WriteLine("Default case");
        //            break;
        //    }
        //}
    }





}
