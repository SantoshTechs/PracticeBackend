using CRUD.CommonLayer.Models;
using CRUD.CommonUtility;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CRUD.RepositoryLayer
{
    public class CrudAppliactionRL : ICrudAppliactionRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;
        public readonly MySqlConnection _mySqlConnection;
        int ConnectionTimeOut = 180;
        public CrudAppliactionRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration["ConnectionStrings:SqlServerDBConnection"]);
           
        }

        public async Task<CreateInformationResponse> CreateInformation(CreateInformationRequest request)
        {
            CreateInformationResponse resposne = new CreateInformationResponse();
            resposne.IsSuccess = true;
            resposne.Message = "Successful";
            try
            {
               
                if (_sqlConnection != null)
                {
                    string StoreProcedure = "SpCreateInformation";
                    using (SqlCommand sqlCommand = new SqlCommand(StoreProcedure, _sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.CommandTimeout = ConnectionTimeOut;
                        sqlCommand.Parameters.AddWithValue("@fullName", request.fullName);
                        sqlCommand.Parameters.AddWithValue("@company", request.company);
                        sqlCommand.Parameters.AddWithValue("@role", request.role);
                        sqlCommand.Parameters.AddWithValue("@emailId", request.emailId);
                        sqlCommand.Parameters.AddWithValue("@mobileNumber", request.mobileNumber);
                        sqlCommand.Parameters.AddWithValue("@note1", request.note1);
                        sqlCommand.Parameters.AddWithValue("@messageNote", request.messageNote);
                      
                        //
                        await _sqlConnection.OpenAsync();
                        int Status = await sqlCommand.ExecuteNonQueryAsync();
                        if (Status <= 0)
                        {
                            resposne.IsSuccess = false;
                            resposne.Message = "CreateInformation Not Executed";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                resposne.IsSuccess = false;
                resposne.Message = "Exception Message : " + ex.Message;
            }
            finally
            {
               
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return resposne;
        }

    
        
    }
}
