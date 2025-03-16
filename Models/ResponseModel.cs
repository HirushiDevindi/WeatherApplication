
//when we request data from api need to check our req is succes or not 
namespace WeatherApplication.Models{

    public class ResponseModel{

        //define properties for that
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        //when not sure about the return type of this like string or jsondata , then keeep that variable type as dynamic
        public dynamic? JsonData { get; set; }

        //create methods for return values 
        public static ResponseModel Success(dynamic jsonData){
            return new ResponseModel{
                JsonData = jsonData,
                Message =null,
                IsSuccess =true
            };
        }

        public static ResponseModel Error(string errorMessage){
            return new ResponseModel{
                JsonData = null,
                Message = errorMessage,
                IsSuccess =false
            };
        }


}
}