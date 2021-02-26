using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDbTest1.Data.Mapping
{
    public partial class LogsMap
        : IEntityTypeConfiguration<CleanArchitectureDbTest1.Data.Entities.Logs>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CleanArchitectureDbTest1.Data.Entities.Logs> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Logs", "EventLogging");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Message)
                .HasColumnName("Message")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.MessageTemplate)
                .HasColumnName("MessageTemplate")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.Level)
                .HasColumnName("Level")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.TimeStamp)
                .HasColumnName("TimeStamp")
                .HasColumnType("datetime");

            builder.Property(t => t.Exception)
                .HasColumnName("Exception")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.Properties)
                .HasColumnName("Properties")
                .HasColumnType("nvarchar(max)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "EventLogging";
            public const string Name = "Logs";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string Message = "Message";
            public const string MessageTemplate = "MessageTemplate";
            public const string Level = "Level";
            public const string TimeStamp = "TimeStamp";
            public const string Exception = "Exception";
            public const string Properties = "Properties";
        }
        #endregion
    }
}
