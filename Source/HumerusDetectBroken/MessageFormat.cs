using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LCM.LCM;

namespace LCMTypes
{
    public sealed class imageReady_t : LCM.LCM.LCMEncodable
    {
        public String imageFilename;
        public short imageNumber;

        public imageReady_t()
        {
        }

        public static readonly ulong LCM_FINGERPRINT;
        public static readonly ulong LCM_FINGERPRINT_BASE = 0xaa962bd91b2d186eL;

        static imageReady_t()
        {
            LCM_FINGERPRINT = _hashRecursive(new List<String>());
        }

        public static ulong _hashRecursive(List<String> classes)
        {
            if (classes.Contains("exlcm.imageReady_t"))
                return 0L;

            classes.Add("exlcm.imageReady_t");
            ulong hash = LCM_FINGERPRINT_BASE
                ;
            classes.RemoveAt(classes.Count - 1);
            return (hash << 1) + ((hash >> 63) & 1);
        }

        public void Encode(LCMDataOutputStream outs)
        {
            outs.Write((long)LCM_FINGERPRINT);
            _encodeRecursive(outs);
        }

        public void _encodeRecursive(LCMDataOutputStream outs)
        {
            byte[] __strbuf = null;
            __strbuf = System.Text.Encoding.GetEncoding("US-ASCII").GetBytes(this.imageFilename); outs.Write(__strbuf.Length + 1); outs.Write(__strbuf, 0, __strbuf.Length); outs.Write((byte)0);

            outs.Write(this.imageNumber);

        }

        public imageReady_t(byte[] data)
            : this(new LCMDataInputStream(data))
        {
        }

        public imageReady_t(LCMDataInputStream ins)
        {
            if ((ulong)ins.ReadInt64() != LCM_FINGERPRINT)
                throw new System.IO.IOException("LCM Decode error: bad fingerprint");

            _decodeRecursive(ins);
        }

        public static LCMTypes.imageReady_t _decodeRecursiveFactory(LCMDataInputStream ins)
        {
            LCMTypes.imageReady_t o = new LCMTypes.imageReady_t();
            o._decodeRecursive(ins);
            return o;
        }

        public void _decodeRecursive(LCMDataInputStream ins)
        {
            byte[] __strbuf = null;
            __strbuf = new byte[ins.ReadInt32() - 1]; ins.ReadFully(__strbuf); ins.ReadByte(); this.imageFilename = System.Text.Encoding.GetEncoding("US-ASCII").GetString(__strbuf);

            this.imageNumber = ins.ReadInt16();

        }

        public LCMTypes.imageReady_t Copy()
        {
            LCMTypes.imageReady_t outobj = new LCMTypes.imageReady_t();
            outobj.imageFilename = this.imageFilename;

            outobj.imageNumber = this.imageNumber;

            return outobj;
        }
    }

    public sealed class imageEnhanced_t : LCM.LCM.LCMEncodable
    {
        public String imageFilename;
        public short jointX;
        public short jointY;
        public short radius;

        public imageEnhanced_t()
        {
        }

        public static readonly ulong LCM_FINGERPRINT;
        public static readonly ulong LCM_FINGERPRINT_BASE = 0xcb1ab8eafabe7709L;

        static imageEnhanced_t()
        {
            LCM_FINGERPRINT = _hashRecursive(new List<String>());
        }

        public static ulong _hashRecursive(List<String> classes)
        {
            if (classes.Contains("exlcm.imageEnhanced_t"))
                return 0L;

            classes.Add("exlcm.imageEnhanced_t");
            ulong hash = LCM_FINGERPRINT_BASE
                ;
            classes.RemoveAt(classes.Count - 1);
            return (hash << 1) + ((hash >> 63) & 1);
        }

        public void Encode(LCMDataOutputStream outs)
        {
            outs.Write((long)LCM_FINGERPRINT);
            _encodeRecursive(outs);
        }

        public void _encodeRecursive(LCMDataOutputStream outs)
        {
            byte[] __strbuf = null;
            __strbuf = System.Text.Encoding.GetEncoding("US-ASCII").GetBytes(this.imageFilename); outs.Write(__strbuf.Length + 1); outs.Write(__strbuf, 0, __strbuf.Length); outs.Write((byte)0);

            outs.Write(this.jointX);

            outs.Write(this.jointY);

            outs.Write(this.radius);

        }

        public imageEnhanced_t(byte[] data)
            : this(new LCMDataInputStream(data))
        {
        }

        public imageEnhanced_t(LCMDataInputStream ins)
        {
            if ((ulong)ins.ReadInt64() != LCM_FINGERPRINT)
                throw new System.IO.IOException("LCM Decode error: bad fingerprint");

            _decodeRecursive(ins);
        }

        public static LCMTypes.imageEnhanced_t _decodeRecursiveFactory(LCMDataInputStream ins)
        {
            LCMTypes.imageEnhanced_t o = new LCMTypes.imageEnhanced_t();
            o._decodeRecursive(ins);
            return o;
        }

        public void _decodeRecursive(LCMDataInputStream ins)
        {
            byte[] __strbuf = null;
            __strbuf = new byte[ins.ReadInt32() - 1]; ins.ReadFully(__strbuf); ins.ReadByte(); this.imageFilename = System.Text.Encoding.GetEncoding("US-ASCII").GetString(__strbuf);

            this.jointX = ins.ReadInt16();

            this.jointY = ins.ReadInt16();

            this.radius = ins.ReadInt16();

        }

        public LCMTypes.imageEnhanced_t Copy()
        {
            LCMTypes.imageEnhanced_t outobj = new LCMTypes.imageEnhanced_t();
            outobj.imageFilename = this.imageFilename;

            outobj.jointX = this.jointX;

            outobj.jointY = this.jointY;

            outobj.radius = this.radius;

            return outobj;
        }
    }

    public sealed class submitVote_t : LCM.LCM.LCMEncodable
    {
        public String imageFilename;
        public short imageNumber;
        public String agentName;
        public String agentAuthor;
        public String vote;

        public submitVote_t()
        {
        }

        public static readonly ulong LCM_FINGERPRINT;
        public static readonly ulong LCM_FINGERPRINT_BASE = 0x8056e51b6ae86498L;

        static submitVote_t()
        {
            LCM_FINGERPRINT = _hashRecursive(new List<String>());
        }

        public static ulong _hashRecursive(List<String> classes)
        {
            if (classes.Contains("exlcm.submitVote_t"))
                return 0L;

            classes.Add("exlcm.submitVote_t");
            ulong hash = LCM_FINGERPRINT_BASE
                ;
            classes.RemoveAt(classes.Count - 1);
            return (hash << 1) + ((hash >> 63) & 1);
        }

        public void Encode(LCMDataOutputStream outs)
        {
            outs.Write((long)LCM_FINGERPRINT);
            _encodeRecursive(outs);
        }

        public void _encodeRecursive(LCMDataOutputStream outs)
        {
            byte[] __strbuf = null;
            __strbuf = System.Text.Encoding.GetEncoding("US-ASCII").GetBytes(this.imageFilename); outs.Write(__strbuf.Length + 1); outs.Write(__strbuf, 0, __strbuf.Length); outs.Write((byte)0);

            outs.Write(this.imageNumber);

            __strbuf = System.Text.Encoding.GetEncoding("US-ASCII").GetBytes(this.agentName); outs.Write(__strbuf.Length + 1); outs.Write(__strbuf, 0, __strbuf.Length); outs.Write((byte)0);

            __strbuf = System.Text.Encoding.GetEncoding("US-ASCII").GetBytes(this.agentAuthor); outs.Write(__strbuf.Length + 1); outs.Write(__strbuf, 0, __strbuf.Length); outs.Write((byte)0);

            __strbuf = System.Text.Encoding.GetEncoding("US-ASCII").GetBytes(this.vote); outs.Write(__strbuf.Length + 1); outs.Write(__strbuf, 0, __strbuf.Length); outs.Write((byte)0);

        }

        public submitVote_t(byte[] data)
            : this(new LCMDataInputStream(data))
        {
        }

        public submitVote_t(LCMDataInputStream ins)
        {
            if ((ulong)ins.ReadInt64() != LCM_FINGERPRINT)
                throw new System.IO.IOException("LCM Decode error: bad fingerprint");

            _decodeRecursive(ins);
        }

        public static LCMTypes.submitVote_t _decodeRecursiveFactory(LCMDataInputStream ins)
        {
            LCMTypes.submitVote_t o = new LCMTypes.submitVote_t();
            o._decodeRecursive(ins);
            return o;
        }

        public void _decodeRecursive(LCMDataInputStream ins)
        {
            byte[] __strbuf = null;
            __strbuf = new byte[ins.ReadInt32() - 1]; ins.ReadFully(__strbuf); ins.ReadByte(); this.imageFilename = System.Text.Encoding.GetEncoding("US-ASCII").GetString(__strbuf);

            this.imageNumber = ins.ReadInt16();

            __strbuf = new byte[ins.ReadInt32() - 1]; ins.ReadFully(__strbuf); ins.ReadByte(); this.agentName = System.Text.Encoding.GetEncoding("US-ASCII").GetString(__strbuf);

            __strbuf = new byte[ins.ReadInt32() - 1]; ins.ReadFully(__strbuf); ins.ReadByte(); this.agentAuthor = System.Text.Encoding.GetEncoding("US-ASCII").GetString(__strbuf);

            __strbuf = new byte[ins.ReadInt32() - 1]; ins.ReadFully(__strbuf); ins.ReadByte(); this.vote = System.Text.Encoding.GetEncoding("US-ASCII").GetString(__strbuf);

        }

        public LCMTypes.submitVote_t Copy()
        {
            LCMTypes.submitVote_t outobj = new LCMTypes.submitVote_t();
            outobj.imageFilename = this.imageFilename;

            outobj.imageNumber = this.imageNumber;

            outobj.agentName = this.agentName;

            outobj.agentAuthor = this.agentAuthor;

            outobj.vote = this.vote;

            return outobj;
        }
    }
}
