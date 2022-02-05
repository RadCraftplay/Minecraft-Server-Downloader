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
    public class VersionListFile : IEquatable<VersionListFile>
    {
	    public bool Equals(VersionListFile other)
	    {
		    if (ReferenceEquals(null, other)) return false;
		    if (ReferenceEquals(this, other)) return true;
		    return Equals(versions, other.versions);
	    }

	    public override bool Equals(object obj)
	    {
		    if (ReferenceEquals(null, obj)) return false;
		    if (ReferenceEquals(this, obj)) return true;
		    if (obj.GetType() != this.GetType()) return false;
		    return Equals((VersionListFile)obj);
	    }

	    public override int GetHashCode()
	    {
		    return (versions != null ? versions.GetHashCode() : 0);
	    }

	    public static bool operator ==(VersionListFile left, VersionListFile right)
	    {
		    return Equals(left, right);
	    }

	    public static bool operator !=(VersionListFile left, VersionListFile right)
	    {
		    return !Equals(left, right);
	    }

	    public class MinecraftVersion : IEquatable<MinecraftVersion>
        {
	        public bool Equals(MinecraftVersion other)
	        {
		        if (ReferenceEquals(null, other)) return false;
		        if (ReferenceEquals(this, other)) return true;
		        return id == other.id && url == other.url;
	        }

	        public override bool Equals(object obj)
	        {
		        if (ReferenceEquals(null, obj)) return false;
		        if (ReferenceEquals(this, obj)) return true;
		        if (obj.GetType() != this.GetType()) return false;
		        return Equals((MinecraftVersion)obj);
	        }

	        public override int GetHashCode()
	        {
		        unchecked
		        {
			        return ((id != null ? id.GetHashCode() : 0) * 397) ^ (url != null ? url.GetHashCode() : 0);
		        }
	        }

	        public static bool operator ==(MinecraftVersion left, MinecraftVersion right)
	        {
		        return Equals(left, right);
	        }

	        public static bool operator !=(MinecraftVersion left, MinecraftVersion right)
	        {
		        return !Equals(left, right);
	        }

	        public string id;
            public string url;
        }

        public List<MinecraftVersion> versions;
    }
}
