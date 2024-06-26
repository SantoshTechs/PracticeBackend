﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.CommonUtility
{
    public class SqlQueries
    {

        static IConfiguration _sqlQueryConfiguration = new ConfigurationBuilder()
            .AddXmlFile("SqlQueries.xml", true, true)
            .Build();

        public static string CreateInformationQuery { get { return _sqlQueryConfiguration["CreateInformationQuery"]; } }
       
    }
}
