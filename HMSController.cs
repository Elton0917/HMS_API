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
        #region PUT
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

    #region HMS_Manage_Health_Controller
    public class HMS_MHController : ApiController
    {
        static readonly IHMS_MHRepository repository = new HMS_MHRepository();
        #region GET
        public IEnumerable<HMS_ManageHealth> GetMH()
        {
            return repository.GetMH();
        }
        public HMS_ManageHealth Get(string UID)
        {
            HMS_ManageHealth message = repository.Get(UID);
            if (message == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return message;
        }
        #endregion
        #region POST
        public HttpResponseMessage PostMessage(HMS_ManageHealth msg)
        {
            HMS_ManageHealth newMsg = repository.Add(msg);

            var response = Request.CreateResponse(HttpStatusCode.Created, newMsg);

            response.Headers.Location = new Uri(Request.RequestUri, "/api/HMS_MH/" + newMsg.UID.ToString());

            return response;
        }
        #endregion
        #region DELETE
        public HMS_ManageHealth DeleteMessage(string UID, string MHID)
        {

            HMS_ManageHealth message = repository.Remove(UID, MHID);
            if (message == null)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent); //204
            }

            return message;
        }
        #endregion
        #region PUT
        public void PutMessage(HMS_ManageHealth msg)
        {
            if (!repository.Update(msg))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)); //404
            }

        }
        #endregion
    }
    #endregion

    #region HMS_Health_Item_Controller
    public class HMS_HIController : ApiController
    {
        static readonly IHMS_HIRepository repository = new HMS_HIRepository();
        #region GET
        public IEnumerable<HMS_Health_Item> GetHI()
        {
            return repository.GetHI();
        }
        public HMS_Health_Item Get(string HIID)
        {
            HMS_Health_Item message = repository.Get(HIID);
            if (message == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return message;
        }
        #endregion
    }
    #endregion

    #region HMS_Group_Controller
    public class HMS_GPController : ApiController
    {
        static readonly IHMS_GPRepository repository = new HMS_GPRepository();
        #region GET
        public IEnumerable<HMS_Group> GetGP()
        {
            return repository.GetGP();
        }
        public HMS_Group Get(string GID)
        {
            HMS_Group message = repository.Get(GID);
            if (message == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return message;
        }
        #endregion
        //#region POST
        //public HttpResponseMessage PostMessage(HMS_Group msg)
        //{
        //    HMS_Group newMsg = repository.Add(msg);

        //    var response = Request.CreateResponse(HttpStatusCode.Created, newMsg);

        //    response.Headers.Location = new Uri(Request.RequestUri, "/api/HMS_GP/" + newMsg.UID.ToString());

        //    return response;
        //}
        //#endregion
        //#region DELETE
        //public HMS_Group DeleteMessage(string UID, string MHID)
        //{

        //    HMS_Group message = repository.Remove(UID, MHID);
        //    if (message == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NoContent); //204
        //    }

        //    return message;
        //}
        //#endregion
        //#region PUT
        //public void PutMessage(HMS_Group msg)
        //{
        //    if (!repository.Update(msg))
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)); //404
        //    }

        //}
        //#endregion
    }
    #endregion
}