using System;
using System.IO;
using Apache.Ibatis.Common.Resources;
using NUnit.Framework;

namespace Apache.Ibatis.Common.Test.Fixtures.Resources
{
    [TestFixture]
    public class CustomUriBuilderTest
    {
        protected const string TemporaryFileName = "temp.file";

        protected static FileInfo CreateFileForTheCurrentDirectory()
        {
            return new FileInfo(Path.GetFullPath(
                                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TemporaryFileName)));
        }

        [Test]
        public void Resolve_with_protocol_and_special_home_character()
        {
            FileInfo fileInfo = CreateFileForTheCurrentDirectory();

            CustomUriBuilder builder = new CustomUriBuilder("file://~/" + TemporaryFileName, null);

            Assert.AreEqual(fileInfo.FullName, builder.Uri.LocalPath,
                "The file name with file://~ must have resolved to a file " +
                "in the current directory of the currently executing domain.");
        }

        [Test]
        public void Resolve_with_protocol_and_special_home_character_in_parent_directory()
        {
            FileInfo file = new FileInfo(Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TemporaryFileName)));

            CustomUriBuilder builder = new CustomUriBuilder("file://~/../" + TemporaryFileName, null);

            string fileNameOneDirectoryUp = file.Directory.Parent.FullName + "\\" + TemporaryFileName;
            Assert.AreEqual(fileNameOneDirectoryUp, builder.Uri.LocalPath,
                "The file name with file://~/.. must have resolved to a file " +
                "in the parent directory of the currently executing domain.");
        }
    }
}
