
using System;

namespace mydapper.Repository
{
    public class QueryResult
    {
        private readonly Tuple<string, dynamic> _result;

        public string Sql
        {
            get
            {
                return this._result.Item1;
            }
        }
        public dynamic Param
        {
            get
            {
                return this._result.Item2;
            }
        }

        public QueryResult(string sql, dynamic param)
        {
            this._result = new Tuple<string, dynamic>(sql, param);
        }
    }
}