// This file is part of Minecraft Server Downloader.
// 
// Copyright (C) 2016-2022 Distroir
// 
// Minecraft Server Downloader is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Minecraft Server Downloader is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
// Email: radcraftplay2@gmail.com

namespace Minecraft_Server_Downloader.Core.Downloaders
{
    public class AsyncDownloadProgress
    {
        public AsyncDownloadProgress(int current, int all)
        {
            Current = current;
            All = all;
            Completed = false;
        }

        public AsyncDownloadProgress(int current, int all, bool completed)
        {
	        Current = current;
	        All = all;
	        Completed = completed;
        }

        public int Current { get; }
        public int All { get; }
        public bool Completed { get; }
    }
}
