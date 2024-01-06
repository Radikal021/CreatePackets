using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaselServerTest.Classes
{
    internal class CreatePacket
    {
        List<byte> packetData = new List<byte>();
        short freamCounter = 0;
        public byte Source = 0x11;
        public byte Destenation = 0x10;
        public void GenPacket(byte opCode, List<byte> upconvert, List<byte> downconvert, List<byte> rfHead, List<byte> RxBeanFormer, List<byte> TxBeanFormer, List<byte> MainSwitch, List<byte> SubPower)
        {
            freamCounter++;
            packetData.Add(0x68); packetData.Add(0x65); packetData.Add(0x61); packetData.Add(0x64);  //HEAD
            byte[] aData = BitConverter.GetBytes(freamCounter);
            for (int i = 0; i < aData.Length; i++) packetData.Add(aData[i]);//freamCounter
            packetData.Add(0x0B); //DataType
            packetData.Add(Source);  // Source
            packetData.Add(Destenation); //Dest
            packetData.Add(opCode);     //Opcode
            int size = upconvert.Count + downconvert.Count + rfHead.Count + RxBeanFormer.Count + TxBeanFormer.Count + MainSwitch.Count + SubPower.Count; //Size
            aData = BitConverter.GetBytes(size);
            for (int i = 0; i < aData.Length; i++) packetData.Add(aData[i]);
            packetData.AddRange(upconvert);     //Data
            packetData.AddRange(downconvert);   //Data
            packetData.AddRange(rfHead);        //Data
            packetData.AddRange(RxBeanFormer);  //Data
            packetData.AddRange(TxBeanFormer);  //Data
            packetData.AddRange(MainSwitch);    //Data
            packetData.AddRange(SubPower);      //Data
            //upconvert.ToArray();
            packetData.Add(0xAA); //Footer
            packetData.Add(0xBB); //Footer
            packetData.Add(0xCC); //Footer
            packetData.Add(0xDD); //Footer
            packetData.ToArray();
        }
    }
}
