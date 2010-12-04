using System;
using System.Collections.Generic;
using System.Data;
using Spring.Data.Common;
using Spring.Data.Objects;
using System.Linq;
using System.Web;
using Spring.Data.Generic;
using System.Collections;
using System.Web.Security;
using rpcwc.vo.Directory;
using Spring.Data;
using Spring.Data.Support;

/// <summary>
/// Summary description for GuestRegistrationDAOSQL
/// </summary>
namespace rpcwc.dao.sql
{
    public class GuestRegistrationDAOSQL : RPCWCDAO, IGuestRegistrationDAO
    {
        public String CreateSql { get; set; }
        public String GetReportSql { get; set; }
        public String TagGuestSql { get; set; }
        public class GuestRegistrationCreateNonQuery : Spring.Data.Objects.AdoNonQuery
        {
            public GuestRegistrationCreateNonQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.Text;
                DeclaredParameters = new DbParameters(dbProvider); 
                DeclaredParameters.Add("name", SqlDbType.VarChar);
                DeclaredParameters.Add("address", SqlDbType.VarChar);
                DeclaredParameters.Add("phone", SqlDbType.VarChar);
                DeclaredParameters.Add("email", SqlDbType.VarChar);
                DeclaredParameters.Add("visited", SqlDbType.Bit);
                DeclaredParameters.Add("visitDate", SqlDbType.SmallDateTime);
                DeclaredParameters.Add("college", SqlDbType.Bit);
                DeclaredParameters.Add("newtoarea", SqlDbType.Bit);
                DeclaredParameters.Add("howhear", SqlDbType.VarChar);
                DeclaredParameters.Add("contactme", SqlDbType.Bit);
                DeclaredParameters.Add("faith", SqlDbType.Bit);
                DeclaredParameters.Add("churchhome", SqlDbType.Bit);
                DeclaredParameters.Add("worship", SqlDbType.Bit);
                DeclaredParameters.Add("teaching", SqlDbType.Bit);
                DeclaredParameters.Add("youth", SqlDbType.Bit);
                DeclaredParameters.Add("service", SqlDbType.Bit);
                DeclaredParameters.Add("love", SqlDbType.Bit);
                DeclaredParameters.Add("evangelism", SqlDbType.Bit);
                DeclaredParameters.Add("othertext", SqlDbType.Text);
                DeclaredParameters.Add("commentsprayer", SqlDbType.Text);
                //DeclaredParameters.Add("create_date", SqlDbType.DateTime);
                DeclaredParameters.Add("create_user", SqlDbType.VarChar);
                //DeclaredParameters.Add("last_upd_date", SqlDbType.Timestamp);
                DeclaredParameters.Add("last_upd_user", SqlDbType.VarChar);
                Compile();
            }
        }

        public class TagGuestNonQuery : Spring.Data.Objects.AdoNonQuery
        {
            public TagGuestNonQuery(IDbProvider dbProvider, string sql)
                : base(dbProvider, sql)
            {
                CommandType = CommandType.Text;
                DeclaredParameters = new DbParameters(dbProvider);
                DeclaredParameters.Add("guest_id", SqlDbType.Int);
                DeclaredParameters.Add("tag_cd", SqlDbType.VarChar);
                Compile();
            }
        }

        public void SaveGuestRegistration(GuestRegistration guestRegistration)
        {
            MembershipUser currentUser = Membership.GetUser();
            String currentUserName = null;
            if (currentUser != null) {
                currentUserName = currentUser.UserName;
            }

            GuestRegistrationCreateNonQuery nonQuery = new GuestRegistrationCreateNonQuery(dbProvider, CreateSql);
            IDictionary paramMap = new Hashtable();
            paramMap.Add("@name", guestRegistration.Name);
            paramMap.Add("@address", guestRegistration.Address);
            paramMap.Add("@phone", guestRegistration.phone);
            paramMap.Add("@email", guestRegistration.email);
            paramMap.Add("@visited", guestRegistration.visited);
            paramMap.Add("@visitDate", guestRegistration.visitDate);
            paramMap.Add("@college", guestRegistration.college);
            paramMap.Add("@newtoarea", guestRegistration.newtoarea);
            paramMap.Add("@howhear", guestRegistration.howhear);
            paramMap.Add("@contactme", guestRegistration.contactme);
            paramMap.Add("@faith", guestRegistration.faith);
            paramMap.Add("@churchhome", guestRegistration.churchhome);
            paramMap.Add("@worship", guestRegistration.worship);
            paramMap.Add("@teaching", guestRegistration.teaching);
            paramMap.Add("@youth", guestRegistration.youth);
            paramMap.Add("@service", guestRegistration.service);
            paramMap.Add("@love", guestRegistration.love);
            paramMap.Add("@evangelism", guestRegistration.evangelism);
            paramMap.Add("@othertext", guestRegistration.othertext);
            paramMap.Add("@commentsprayer", guestRegistration.commentsprayer);
            //paramMap.Add("@create_date", DateTime.Now);
            paramMap.Add("@create_user", currentUserName);
            //paramMap.Add("@last_upd_date", new DateTime());
            paramMap.Add("@last_upd_user", currentUserName);
            nonQuery.ExecuteNonQueryByNamedParam(paramMap);
        }

        public void TagGuest(GuestRegistration guestRegistration, String tagCode)
        {
            MembershipUser currentUser = Membership.GetUser();
            String currentUserName = null;
            if (currentUser != null)
            {
                currentUserName = currentUser.UserName;
            }

            TagGuestNonQuery nonQuery = new TagGuestNonQuery(dbProvider, TagGuestSql);
            IDictionary paramMap = new Hashtable();
            paramMap.Add("@guest_id", guestRegistration.ID);
            paramMap.Add("@tag_cd", tagCode);

            nonQuery.ExecuteNonQueryByNamedParam(paramMap);

        }

        protected class GetReportQuery : Spring.Data.Objects.Generic.MappingAdoQuery
        {
            public GetReportQuery(IDbProvider dbProvider, String sql)
                : base(dbProvider, sql)
            {
                Compile();
            }

            enum OutParams
            {
                id,
                name,
                address,
                phone,
                email,
                visited,
                visitdate,
                college,
                newtoarea,
                howhear,
                contactme,
                faith,
                churchhome,
                worship,
                teaching,
                youth,
                service,
                love,
                evangelism, 
                othertext,
                commentsprayer,
                create_date,
                create_user,
                last_upd_date,
                last_upd_user
            }

            protected override T MapRow<T>(IDataReader xreader, int num)
            {
                NullMappingDataReader reader = new NullMappingDataReader(xreader);
                GuestRegistration guestRegistration = new GuestRegistration();
                
                guestRegistration.ID = reader.GetInt32((int)OutParams.id);
                guestRegistration.Name = reader.GetString((int) OutParams.name);

                guestRegistration.Address = reader.GetString((int) OutParams.address);;
                guestRegistration.phone = reader.GetString((int) OutParams.phone);;
                guestRegistration.email = reader.GetString((int) OutParams.email);;
                guestRegistration.visited = reader.GetBoolean((int) OutParams.visited);;
                guestRegistration.visitDate = reader.GetDateTime((int) OutParams.visitdate);
                guestRegistration.college = reader.GetBoolean((int) OutParams.college);;
                guestRegistration.newtoarea = reader.GetBoolean((int) OutParams.newtoarea);;
                guestRegistration.howhear = reader.GetString((int) OutParams.howhear);;
                guestRegistration.contactme = reader.GetBoolean((int) OutParams.contactme);;
                guestRegistration.faith = reader.GetBoolean((int) OutParams.faith);;
                guestRegistration.churchhome = reader.GetBoolean((int) OutParams.churchhome);;
                guestRegistration.worship = reader.GetBoolean((int) OutParams.worship);;
                guestRegistration.teaching = reader.GetBoolean((int) OutParams.teaching);;
                guestRegistration.youth = reader.GetBoolean((int) OutParams.youth);;
                guestRegistration.service = reader.GetBoolean((int) OutParams.service);;
                guestRegistration.love = reader.GetBoolean((int) OutParams.love);;
                guestRegistration.evangelism = reader.GetBoolean((int) OutParams.evangelism);;
                guestRegistration.othertext = reader.GetString((int) OutParams.othertext);;
                guestRegistration.commentsprayer = reader.GetString((int) OutParams.commentsprayer);;
                guestRegistration.createDate = reader.GetDateTime((int) OutParams.create_date);
                guestRegistration.createUser = reader.GetString((int) OutParams.create_user);;
                guestRegistration.lastUpdateDate = reader.GetDateTime((int) OutParams.last_upd_date);
                guestRegistration.lastUpdateUser = reader.GetString((int) OutParams.last_upd_user);
                return (T) (Object) guestRegistration;
            }
        }

        public IList<GuestRegistration> GetReport(string reportName)
        {
            GetReportQuery query = new GetReportQuery(dbProvider, GetReportSql);
            return query.Query<GuestRegistration>();
        }
    }
}