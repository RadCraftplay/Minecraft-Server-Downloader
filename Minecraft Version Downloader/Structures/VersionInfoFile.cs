/*
	This file is part of Minecraft Server Downloader.

	Copyright (C) 2016-2020 Distroir

	Minecraft Server Downloader is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	Minecraft Server Downloader is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.

	Email: radcraftplay2@gmail.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minecraft_Server_Downloader.Structures
{
    public class VersionInfoFile : IEquatable<VersionInfoFile>
    {
	    public bool Equals(VersionInfoFile other)
	    {
		    if (ReferenceEquals(null, other)) return false;
		    if (ReferenceEquals(this, other)) return true;
		    return id == other.id && type == other.type && Equals(downloads, other.downloads);
	    }

	    public override bool Equals(object obj)
	    {
		    if (ReferenceEquals(null, obj)) return false;
		    if (ReferenceEquals(this, obj)) return true;
		    if (obj.GetType() != this.GetType()) return false;
		    return Equals((VersionInfoFile)obj);
	    }

	    public override int GetHashCode()
	    {
		    unchecked
		    {
			    var hashCode = (id != null ? id.GetHashCode() : 0);
			    hashCode = (hashCode * 397) ^ (type != null ? type.GetHashCode() : 0);
			    hashCode = (hashCode * 397) ^ (downloads != null ? downloads.GetHashCode() : 0);
			    return hashCode;
		    }
	    }

	    public static bool operator ==(VersionInfoFile left, VersionInfoFile right)
	    {
		    return Equals(left, right);
	    }

	    public static bool operator !=(VersionInfoFile left, VersionInfoFile right)
	    {
		    return !Equals(left, right);
	    }

	    public class MinecraftDownloads : IEquatable<MinecraftDownloads>
        {
	        public bool Equals(MinecraftDownloads other)
	        {
		        if (ReferenceEquals(null, other)) return false;
		        if (ReferenceEquals(this, other)) return true;
		        return Equals(server, other.server);
	        }

	        public override bool Equals(object obj)
	        {
		        if (ReferenceEquals(null, obj)) return false;
		        if (ReferenceEquals(this, obj)) return true;
		        if (obj.GetType() != this.GetType()) return false;
		        return Equals((MinecraftDownloads)obj);
	        }

	        public override int GetHashCode()
	        {
		        return (server != null ? server.GetHashCode() : 0);
	        }

	        public static bool operator ==(MinecraftDownloads left, MinecraftDownloads right)
	        {
		        return Equals(left, right);
	        }

	        public static bool operator !=(MinecraftDownloads left, MinecraftDownloads right)
	        {
		        return !Equals(left, right);
	        }

	        public class MinecraftDownloadInfo : IEquatable<MinecraftDownloadInfo>
            {
	            public bool Equals(MinecraftDownloadInfo other)
	            {
		            if (ReferenceEquals(null, other)) return false;
		            if (ReferenceEquals(this, other)) return true;
		            return size == other.size && url == other.url;
	            }

	            public override bool Equals(object obj)
	            {
		            if (ReferenceEquals(null, obj)) return false;
		            if (ReferenceEquals(this, obj)) return true;
		            if (obj.GetType() != this.GetType()) return false;
		            return Equals((MinecraftDownloadInfo)obj);
	            }

	            public override int GetHashCode()
	            {
		            unchecked
		            {
			            return (size * 397) ^ (url != null ? url.GetHashCode() : 0);
		            }
	            }

	            public static bool operator ==(MinecraftDownloadInfo left, MinecraftDownloadInfo right)
	            {
		            return Equals(left, right);
	            }

	            public static bool operator !=(MinecraftDownloadInfo left, MinecraftDownloadInfo right)
	            {
		            return !Equals(left, right);
	            }

	            public int size;
                public string url;
            }

            public MinecraftDownloadInfo server;
        }

        public string id;
        public string type;
        public MinecraftDownloads downloads;
    }
}
