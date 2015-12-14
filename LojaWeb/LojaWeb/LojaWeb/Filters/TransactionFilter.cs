using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Filters
{
    public class TransactionFilter:ActionFilterAttribute
    {
        private ISession session;

        public TransactionFilter(ISession session) {
            this.session = session;
        
        }

        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            session.BeginTransaction();
        }

       /* public override void OnActionExecuted(ActionExecutedContext ctx)
        {
            if (ctx.Exception == null)
            {
                session.Transaction.Commit();
            }

            else {
                session.Transaction.Rollback();
            }
            session.Close();
        
        }  apenas trocar o nome para sempre manter a sessão*/

         public override void OnResultExecuted(ResultExecutedContext ctx)
        {
            if (ctx.Exception == null)
            {
                session.Transaction.Commit();
            }

            else {
                session.Transaction.Rollback();
            }
            session.Close();
        
        } 


    }
}