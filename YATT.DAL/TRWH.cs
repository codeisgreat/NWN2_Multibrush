/***********************************************************************************
 * YATT - NWN2 Terrain Tool plugin allowing importing of heightmaps, colourmaps, etc
 * Copyright (C) 2006 Simon Noble ( sidefxboy(at)gmail(dot)com )

 * YATT is free software; you can redistribute it and/or modify it under the terms of 
 * the GNU General Public License as published by the Free Software Foundation; 
 * either version 2 of the License, or (at your option) any later version.

 * YATT is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR 
 * PURPOSE. See the GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License along with YATT;
 * if not, write to the Free Software Foundation, Inc., 59 Temple Place, 
 * Suite 330, Boston, MA 02111-1307 USA
 
 * In addition, as a special exception, the copyright holders give permission to link
 * the code of portions of YATT with the NWN2 Toolset libraries under certain 
 * conditions as described in each individual source file, and distribute linked 
 * combinations including the two.
 
 * You must obey the GNU General Public License in all respects for all of the code used 
 * other than that related to the NWN2 Toolset Libraries.  If you modify file(s) with 
 * this exception, you may extend this exception to your version of the file(s), but you 
 * are not obligated to do so.  If you do not wish to do so, delete this exception 
 * statement from your version.  If you delete this exception statement from all source
 * files in the program, then also delete it here.
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace SFX.YATT.DAL
{
    class TRWH : DAL.IPacket
    {
        public OEIShared.Utils.FourCC FourCC
        {
            get
            {
                return this._fourCC;
            }
        }
        private OEIShared.Utils.FourCC _fourCC = new OEIShared.Utils.FourCC( "TRWH" );

        public int Width
        {
            get
            {
                return this._width;
            }
        }
        private int _width;

        public int Height
        {
            get
            {
                return this._height;
            }
        }
        private int _height;

        private int _size;
        private int _padding;

        public TRWH( System.IO.BinaryReader reader )
        {
            this.Load( reader );
        }

        public void Load( System.IO.BinaryReader reader )
        {
            OEIShared.Utils.FourCC cc = new OEIShared.Utils.FourCC( reader.ReadChars( 4 ) );

            if ( cc != this._fourCC )
                throw new ApplicationException( this._fourCC.ToString() + " not found in stream" );

            this._size = reader.ReadInt32();
            this._width = reader.ReadInt32();
            this._height = reader.ReadInt32();
            this._padding = reader.ReadInt32();
        }

        public void Save( System.IO.BinaryWriter writer )
        {
            writer.Write( this._fourCC.IntValue );
            writer.Write( this._size );
            writer.Write( this._width );
            writer.Write( this._height );
            writer.Write( this._padding );
        }
        public override string ToString()
        {
            return "Width: " + this.Width + " Height: " + this.Height + "\n" +
                "Padding: " + this._padding + "\n";
        }
    }
}
