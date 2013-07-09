using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMSAPI
{
        #region HMSController
        public class HMSController : ApiController
        {
            
            // GET api/<controller>
            static readonly IHMSRepository repository = new HMSRepository();

            #region GET
            public IEnumerable<HMS_LUContext> GetAll()
            {
                
                return repository.GetAll();
            }
            public HMS_LUContext Get(string UID)
            {
                HMS_LUContext message = repository.Get(UID);
                if (message == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return message;
            }
            #endregion
            #region POST
            public HttpResponseMessage PostMessage(HMS_LUContext msg)
            {


                HMS_LUContext newMsg = repository.Add(msg);

                var response = Request.CreateResponse(HttpStatusCode.Created, newMsg);

                response.Headers.Location = new Uri(Request.RequestUri, "/api/messages/" + newMsg.UID.ToString());

                return response;
            }
            #endregion
            #region DELETE
            public HMS_LUContext DeleteMessage(string UID)
            {

                HMS_LUContext message = repository.Remove(UID);
                if (message == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NoContent); //204
                }

                return message;
            }
            #endregion
            #region
            public void PutMessage(HMS_LUContext msg)
            {
                if (!repository.Update(msg))
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)); //404
                }

            }
            #endregion
        }
        #endregion
    }