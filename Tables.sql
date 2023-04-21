CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RoleId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               NVARCHAR (450) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider]       NVARCHAR (128) NOT NULL,
    [ProviderKey]         NVARCHAR (128) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [UserId]              NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (450) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (450)     NOT NULL,
    [Discriminator]        NVARCHAR (MAX)     NOT NULL,
    [Firstname]            NVARCHAR (MAX)     NULL,
    [Lastname]             NVARCHAR (MAX)     NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId]        NVARCHAR (450) NOT NULL,
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [Name]          NVARCHAR (128) NOT NULL,
    [Value]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED ([UserId] ASC, [LoginProvider] ASC, [Name] ASC),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AttachmentFile] (
    [Id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [FilePath]     NVARCHAR (MAX) NOT NULL,
    [ContentType]  NVARCHAR (MAX) NULL,
    [FileName]     NVARCHAR (MAX) NULL,
    [Grade]        INT            NOT NULL,
    [Length]       BIGINT         NOT NULL,
    [CreatedDate]  DATETIME2 (7)  NOT NULL,
    [ModifiedDate] DATETIME2 (7)  NOT NULL,
    [CreatedBy]    NVARCHAR (MAX) NOT NULL,
    [ModifiedBy]   NVARCHAR (MAX) NOT NULL,
    [Cancelled]    BIT            NOT NULL,
    CONSTRAINT [PK_AttachmentFile] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Enrollment] (
    [EnrollmentID]    INT            IDENTITY (1, 1) NOT NULL,
    [EmailID]         NVARCHAR (MAX) NULL,
    [CreatedDateTime] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED ([EnrollmentID] ASC)
);

CREATE TABLE [dbo].[NewFeedbacks] (
    [FeedbacksID]     INT            IDENTITY (1, 1) NOT NULL,
    [ModulesID]       NVARCHAR (MAX) NULL,
    [StudentEmailID]  NVARCHAR (MAX) NOT NULL,
    [LecturerEmailID] NVARCHAR (MAX) NOT NULL,
    [Title]           NVARCHAR (MAX) NOT NULL,
    [Grade]           INT            NOT NULL,
    [LecturerComment] NVARCHAR (MAX) NOT NULL,
    [CreatedDateTime] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_NewFeedbacks] PRIMARY KEY CLUSTERED ([FeedbacksID] ASC)
);

CREATE TABLE [dbo].[NewModules] (
    [ModulesID]           NVARCHAR (450) NOT NULL,
    [ModuleSpecification] NVARCHAR (MAX) NOT NULL,
    [ModuleTitle]         NVARCHAR (MAX) NOT NULL,
    [ModuleLevel]         NVARCHAR (MAX) NOT NULL,
    [CreditRating]        NVARCHAR (MAX) NOT NULL,
    [School]              NVARCHAR (MAX) NOT NULL,
    [TotalStudyHours]     NVARCHAR (MAX) NOT NULL,
    [ModuleSummary]       NVARCHAR (MAX) NOT NULL,
    [CreatedDateTime]     DATETIME2 (7)  NULL,
    CONSTRAINT [PK_NewModules] PRIMARY KEY CLUSTERED ([ModulesID] ASC)
);

CREATE TABLE [dbo].[Notifications] (
    [NotificationsID] INT            IDENTITY (1, 1) NOT NULL,
    [UserModulesID]   INT            NOT NULL,
    [EmailID]         NVARCHAR (MAX) NULL,
    [Title]           NVARCHAR (MAX) NULL,
    [Description]     NVARCHAR (MAX) NULL,
    [CreatedDateTime] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED ([NotificationsID] ASC),
    CONSTRAINT [FK_Notifications_UserModules_UserModulesID] FOREIGN KEY ([UserModulesID]) REFERENCES [dbo].[UserModules] ([UserModulesID]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Tasks] (
    [TasksID]         INT            IDENTITY (1, 1) NOT NULL,
    [UserModulesID]   INT            NOT NULL,
    [EmailID]         NVARCHAR (MAX) NULL,
    [Title]           NVARCHAR (MAX) NULL,
    [Description]     NVARCHAR (MAX) NULL,
    [Status]          NVARCHAR (MAX) NULL,
    [CreatedDateTime] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED ([TasksID] ASC),
    CONSTRAINT [FK_Tasks_UserModules_UserModulesID] FOREIGN KEY ([UserModulesID]) REFERENCES [dbo].[UserModules] ([UserModulesID]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[UserModules] (
    [UserModulesID] INT IDENTITY (1, 1) NOT NULL,
    [ModuleID]      INT NOT NULL,
    [EnrollmentID]  INT NOT NULL,
    CONSTRAINT [PK_UserModules] PRIMARY KEY CLUSTERED ([UserModulesID] ASC),
    CONSTRAINT [FK_UserModules_Enrollment_EnrollmentID] FOREIGN KEY ([EnrollmentID]) REFERENCES [dbo].[Enrollment] ([EnrollmentID]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserModules_Module_ModuleID] FOREIGN KEY ([ModuleID]) REFERENCES [dbo].[Module] ([ModuleID]) ON DELETE CASCADE
);