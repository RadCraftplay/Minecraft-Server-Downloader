﻿/*
	This file is part of Minecraft Server Downloader.

	Copyright (C) 2016 Distroir

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
    public class VersionInfoFile
    {
        public class MinecraftDownloads
        {
            public class MinecraftDownloadInfo
            {
                public int size;
                public string url;
            }

            public MinecraftDownloadInfo server;
        }

        public string id;
        public MinecraftDownloads downloads;
    }
}
