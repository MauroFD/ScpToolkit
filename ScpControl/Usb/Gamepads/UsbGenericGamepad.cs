﻿using System;
using ScpControl.ScpCore;
using ScpControl.Utilities;

namespace ScpControl.Usb.Gamepads
{
    public class UsbGenericGamepad : UsbDevice
    {
        /// <summary>
        ///     GUID_DEVINTERFACE_HID
        /// </summary>
        public static Guid DeviceClassGuid
        {
            // https://msdn.microsoft.com/en-us/library/windows/hardware/ff545860(v=vs.85).aspx
            get { return Guid.Parse("{4D1E55B2-F16F-11CF-88CB-001111000030}"); }
        }

        public override bool Open(string devicePath)
        {
            var retval = base.Open(devicePath);

            // since these devices have no MAC address, generate one
            m_Mac = MacAddressGenerator.NewMacAddress;

            return retval;
        }

        public override bool Stop()
        {
            var retval = base.Stop();

            // pad reservation not supported
            m_State = DsState.Disconnected;

            return retval;
        }

        protected override void Process(DateTime now)
        {
            // ignore
        }

        public override bool Pair(byte[] master)
        {
            return false; // ignore
        }

        public override bool Rumble(byte large, byte small)
        {
            return false; // ignore
        }
    }
}
