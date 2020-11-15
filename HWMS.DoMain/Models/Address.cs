using System;
using HWMS.DoMain.Core.Models;

namespace HWMS.DoMain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remark>若基于数据设计的实体模型；1设计在和实体同一张表，没有业务逻辑。2通过外键关联则会增加复杂性（一旦地址改变，是否影响原有记录）</remark>
    public class Address : ValueObject<Address>
    {
        public Address()
        {

        }
        public Address(string province, string city,
            string county, string street)
        {
            this.Province = province;
            this.City = city;
            this.County = county;
            this.Street = street;
        }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; private set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string County { get; private set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; private set; }

        protected override bool EqualsCore(Address other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}