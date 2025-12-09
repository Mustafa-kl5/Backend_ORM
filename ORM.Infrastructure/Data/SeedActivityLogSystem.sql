-- Activity Logging System: Initial Source Systems and Modules
-- Run this script to populate initial data for the ActivityLog system

-- Insert Source Systems
IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'GRC')
BEGIN
    INSERT INTO [AuditLogging].[SourceSystem] (SystemCode, SystemName, IsActive)
    VALUES ('GRC', 'Governance, Risk & Compliance', 1);
END

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'ORM')
BEGIN
    INSERT INTO [AuditLogging].[SourceSystem] (SystemCode, SystemName, IsActive)
    VALUES ('ORM', 'Operational Risk Management', 1);
END

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'BCM')
BEGIN
    INSERT INTO [AuditLogging].[SourceSystem] (SystemCode, SystemName, IsActive)
    VALUES ('BCM', 'Business Continuity Management', 1);
END

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'RCM')
BEGIN
    INSERT INTO [AuditLogging].[SourceSystem] (SystemCode, SystemName, IsActive)
    VALUES ('RCM', 'Regulatory Compliance Management', 1);
END

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'POLICY')
BEGIN
    INSERT INTO [AuditLogging].[SourceSystem] (SystemCode, SystemName, IsActive)
    VALUES ('POLICY', 'Policy Management', 1);
END

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'AUDIT')
BEGIN
    INSERT INTO [AuditLogging].[SourceSystem] (SystemCode, SystemName, IsActive)
    VALUES ('AUDIT', 'Audit Management', 1);
END

-- Get System IDs for module insertion
DECLARE @GrcSystemId INT = (SELECT SourceSystemId FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'GRC');
DECLARE @OrmSystemId INT = (SELECT SourceSystemId FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'ORM');
DECLARE @BcmSystemId INT = (SELECT SourceSystemId FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'BCM');
DECLARE @RcmSystemId INT = (SELECT SourceSystemId FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'RCM');
DECLARE @PolicySystemId INT = (SELECT SourceSystemId FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'POLICY');
DECLARE @AuditSystemId INT = (SELECT SourceSystemId FROM [AuditLogging].[SourceSystem] WHERE SystemCode = 'AUDIT');

-- Insert Source Modules for GRC
IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @GrcSystemId AND ModuleCode = 'USER_MGMT')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@GrcSystemId, 'USER_MGMT', 'User Management', 1);

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @GrcSystemId AND ModuleCode = 'REGULATIONS')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@GrcSystemId, 'REGULATIONS', 'Regulations', 1);

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @GrcSystemId AND ModuleCode = 'CONTROLS')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@GrcSystemId, 'CONTROLS', 'Controls', 1);

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @GrcSystemId AND ModuleCode = 'RISKS')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@GrcSystemId, 'RISKS', 'Risk Management', 1);

-- Insert Source Modules for ORM
IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @OrmSystemId AND ModuleCode = 'LOSS_EVENT')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@OrmSystemId, 'LOSS_EVENT', 'Loss Events', 1);

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @OrmSystemId AND ModuleCode = 'KRI')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@OrmSystemId, 'KRI', 'Key Risk Indicators', 1);

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @OrmSystemId AND ModuleCode = 'RCSA')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@OrmSystemId, 'RCSA', 'Risk Control Self Assessment', 1);

-- Insert Source Modules for BCM
IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @BcmSystemId AND ModuleCode = 'BIA')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@BcmSystemId, 'BIA', 'Business Impact Analysis', 1);

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @BcmSystemId AND ModuleCode = 'RECOVERY_PLAN')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@BcmSystemId, 'RECOVERY_PLAN', 'Recovery Planning', 1);

-- Insert Source Modules for Audit
IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @AuditSystemId AND ModuleCode = 'AUDIT_FINDINGS')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@AuditSystemId, 'AUDIT_FINDINGS', 'Audit Findings', 1);

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @AuditSystemId AND ModuleCode = 'AUDIT_REPORTS')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@AuditSystemId, 'AUDIT_REPORTS', 'Audit Reports', 1);

-- Insert Source Modules for Policy
IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @PolicySystemId AND ModuleCode = 'POLICY_MGMT')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@PolicySystemId, 'POLICY_MGMT', 'Policy Management', 1);

IF NOT EXISTS (SELECT 1 FROM [AuditLogging].[SourceModule] WHERE SourceSystemId = @PolicySystemId AND ModuleCode = 'POLICY_REVIEW')
    INSERT INTO [AuditLogging].[SourceModule] (SourceSystemId, ModuleCode, ModuleName, IsActive)
    VALUES (@PolicySystemId, 'POLICY_REVIEW', 'Policy Review', 1);

PRINT 'ActivityLog System: Source Systems and Modules initialized successfully';
