namespace ORM.Core.DTOs.ActivityLog;

public enum EventType
{
    // Authentication & Authorization
    LoginAttempt,
    LoginSuccess,
    LoginFailed,
    Logout,
    PasswordChange,
    PasswordReset,
    TokenRefresh,
    AccessDenied,
    
    // User Management
    UserCreated,
    UserUpdated,
    UserDeleted,
    UserActivated,
    UserDeactivated,
    UserLocked,
    UserUnlocked,
    RoleAssigned,
    RoleRevoked,
    PermissionGranted,
    PermissionRevoked,
    
    // Data Operations
    DataCreated,
    DataUpdated,
    DataDeleted,
    DataViewed,
    DataExported,
    DataImported,
    BulkDataOperation,
    
    // Workflow & Approvals
    WorkflowStarted,
    WorkflowCompleted,
    ApprovalRequested,
    ApprovalGranted,
    ApprovalRejected,
    StatusChanged,
    
    // Risk Management
    RiskAssessmentCreated,
    RiskAssessmentUpdated,
    RiskAssessmentDeleted,
    RiskMitigated,
    RiskEscalated,
    
    // Audit & Compliance
    AuditLogViewed,
    AuditLogExported,
    ComplianceReportGenerated,
    PolicyViolationDetected,
    
    // System Events
    SystemConfigurationChanged,
    BackupCreated,
    BackupRestored,
    IntegrationExecuted,
    ScheduledTaskExecuted,
    
    // File Operations
    FileUploaded,
    FileDownloaded,
    FileDeleted,
    
    // Search & Query
    SearchPerformed,
    ReportGenerated,
    
    // Other
    CustomEvent
}
