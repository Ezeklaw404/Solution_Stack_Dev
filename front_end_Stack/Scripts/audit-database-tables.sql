-- Audit tables in SolutionStackDb (unified Identity + Orders schema).
-- Run: sqlcmd -S "(localdb)\mssqllocaldb" -i audit-database-tables.sql

SET NOCOUNT ON;

PRINT '=== ORPHAN tables in SolutionStackDb (not in expected schema) ===';
IF DB_ID(N'SolutionStackDb') IS NULL
    PRINT 'Database SolutionStackDb does not exist.';
ELSE
BEGIN
    SELECT t.name AS OrphanTable
    FROM SolutionStackDb.sys.tables t
    WHERE t.is_ms_shipped = 0
      AND t.name NOT IN (
          N'Orders',
          N'AspNetUsers', N'AspNetRoles', N'AspNetUserRoles',
          N'AspNetUserClaims', N'AspNetRoleClaims', N'AspNetUserLogins',
          N'AspNetUserTokens',
          N'__EFMigrationsHistory'
      )
    ORDER BY t.name;
END

PRINT '';
PRINT '=== All user tables in SolutionStackDb (reference) ===';

IF DB_ID(N'SolutionStackDb') IS NOT NULL
    SELECT t.name AS TableName
    FROM SolutionStackDb.sys.tables t
    WHERE t.is_ms_shipped = 0
    ORDER BY t.name;

PRINT '';
PRINT '=== Expected tables present? ===';

IF DB_ID(N'SolutionStackDb') IS NOT NULL
BEGIN
    SELECT e.ExpectedTable,
        CASE WHEN t.name IS NULL THEN N'MISSING' ELSE N'OK' END AS Status
    FROM (VALUES
        (N'Orders'),
        (N'AspNetUsers'), (N'AspNetRoles'), (N'AspNetUserRoles'),
        (N'AspNetUserClaims'), (N'AspNetRoleClaims'), (N'AspNetUserLogins'),
        (N'AspNetUserTokens'),
        (N'__EFMigrationsHistory')
    ) AS e(ExpectedTable)
    LEFT JOIN SolutionStackDb.sys.tables t ON t.name = e.ExpectedTable;
END
