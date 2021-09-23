﻿using System.Diagnostics.Contracts;

namespace Plcway.Communication.Protocols.PLC.Siemens
{
    /// <summary>
    /// 西门子[写]解析后的地址信息
    /// </summary>
    internal class SiemensWriteAddress : SiemensAddress
    {
        public SiemensWriteAddress(SiemensAddress data)
        {
            Contract.Requires(data != null);

            Assignment(data);
        }

        /// <summary>
        /// 要写入的数据
        /// </summary>
        public byte[] WriteData { get; set; }

        /// <summary>
        /// 赋值
        /// </summary>
        private void Assignment(SiemensAddress data)
        {
            Address = data.Address;
            DataType = data.DataType;
            TypeCode = data.TypeCode;
            DbBlock = data.DbBlock;
            BeginAddress = data.BeginAddress;
            ReadWriteLength = data.ReadWriteLength;
            ReadWriteBit = data.ReadWriteBit;
        }
    }
}
