CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "User" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_User" PRIMARY KEY AUTOINCREMENT,
    "UserName" TEXT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240228163633_InitialCreate', '7.0.16');

COMMIT;

