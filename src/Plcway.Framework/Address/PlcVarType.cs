namespace Plcway.Communication.Address
{
    /// <summary>
    /// PLC 变量类型
    /// </summary>
    public enum PlcVarType
    {
        /// <summary>
        /// (bool)
        /// </summary>
        Bit = 0,

        /// <summary>
        /// (8 bits)
        /// </summary>
        Byte = 1,

        /// <summary>
        /// (16 bits, 2 bytes)
        /// </summary>
        Word = 2,

        /// <summary>
        /// (32 bits, 4 bytes)
        /// </summary>
        DWord = 3,

        /// <summary>
        /// (16 bits, 2 bytes)
        /// </summary>
        Int = 4,

        /// <summary>
        /// DInt variable type (32 bits, 4 bytes)
        /// </summary>
        DInt = 5,

        /// <summary>
        /// Real variable type (32 bits, 4 bytes)
        /// </summary>
        Real = 6,

        /// <summary>
        /// LReal variable type (64 bits, 8 bytes)
        /// </summary>
        LReal = 7,

        /// <summary>
        /// Char Array / C-String variable type (variable)
        /// </summary>
        String = 8,

        /// <summary>
        /// S7 String variable type (variable)
        /// </summary>
        S7String = 9,

        /// <summary>
        /// (variable)
        /// </summary>
        S7WString = 10,

        /// <summary>
        /// Timer variable type
        /// </summary>
        Timer = 11,

        /// <summary>
        /// Counter variable type
        /// </summary>
        Counter = 12,

        /// <summary>
        /// DateTIme variable type
        /// </summary>
        DateTime = 13,

        /// <summary>
        /// DateTimeLong variable type
        /// </summary>
        DateTimeLong = 14,
    }
}
