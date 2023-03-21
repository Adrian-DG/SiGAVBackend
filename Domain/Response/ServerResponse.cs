using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class ServerResponse
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }

        public ServerResponse GetResponse(bool status) 
        {
            return status
            ? new ServerResponse { Title = "Ok", Message = "Los cambios se guardaron con exito!!", Status = true }
            : new ServerResponse { Title = "Error", Message = "Algo salio mal durante el proceso !!", Status = false};
        }

		public ServerResponse GetResponse(bool status, string message)
		{
			return new ServerResponse { Title = $"{(status ? "Ok" : "Error")}", Message = message, Status = status };
		}
	}
}