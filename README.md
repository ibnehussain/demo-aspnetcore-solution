# ASP.NET Core Azure Solution

Enterprise-grade ASP.NET Core solution demonstrating microservices architecture, Azure cloud integration, and modern DevOps practices.

## 🏗️ Architecture Overview

### Application Tier
- **Demo.API**: RESTful Web API (.NET 8)
  - Azure Cosmos DB integration with partition key strategy
  - Global exception handling middleware
  - Structured logging with performance tracking
  - Health checks and OpenAPI documentation
- **Demo.Web**: MVC Frontend (.NET 8)
  - HttpClient factory pattern for service communication
  - Responsive UI with Bootstrap framework
  - Centralized error handling

### Data Tier
- **Azure Cosmos DB**: NoSQL document database
  - Partition key: `/category` for optimal performance
  - Session consistency level
  - Optimized for multi-region distribution

### Infrastructure
- **Azure App Service**: PaaS hosting platform
- **Azure DevOps**: CI/CD pipeline automation
- **Application Insights**: Monitoring and telemetry (configurable)

## 🚀 Deployment Architecture

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Developer     │    │  Azure DevOps   │    │  Azure Cloud    │
│                 │    │                 │    │                 │
│ ┌─────────────┐ │    │ ┌─────────────┐ │    │ ┌─────────────┐ │
│ │ Local Dev   │─┼────┼→│ Build Stage │─┼────┼→│ App Service │ │
│ └─────────────┘ │    │ └─────────────┘ │    │ └─────────────┘ │
│                 │    │ ┌─────────────┐ │    │ ┌─────────────┐ │
│ ┌─────────────┐ │    │ │Deploy Stage │─┼────┼→│ Cosmos DB   │ │
│ │ Git Commit  │─┼────┼→│             │ │    │ └─────────────┘ │
│ └─────────────┘ │    │ └─────────────┘ │    │                 │
└─────────────────┘    └─────────────────┘    └─────────────────┘
```

## 📋 CI/CD Pipeline Stages

### 1. **Build Stage**
```yaml
# Triggered on: main branch commits
Jobs:
  - Restore NuGet packages
  - Build solution (.NET 8)
  - Run unit tests (when available)
  - Publish artifacts (zip packages)
```

### 2. **Deploy Stage** 
```yaml
# Environment: Production
Dependencies: [Build Stage]
Jobs:
  - Deploy Demo.API → Azure App Service
  - Deploy Demo.Web → Azure App Service  
  - Configure app settings
  - Health check validation
```

### 3. **Staging Pipeline** (Optional)
```yaml
# Triggered on: develop, feature/* branches
Environment: Staging
Flow: Build → Deploy to Staging Environment
```

## 🔧 Key Implementation Patterns

### **Dependency Injection**
- Singleton CosmosClient with optimized configuration
- HttpClient factory for external service calls
- Scoped controllers with constructor injection

### **Error Handling**
- Global exception handling middleware
- Structured error responses with trace IDs
- Security-focused (no internal details exposed)

### **Performance Optimization**
- Partition key-based queries for Cosmos DB
- Connection pooling and retry policies  
- Request/response logging with timing

### **Security**
- HTTPS enforcement
- Security headers (X-Frame-Options, X-Content-Type-Options)
- Secrets management via Azure App Settings

## 🛠️ Local Development

### Prerequisites
- .NET 8 SDK
- Azure Cosmos DB Emulator
- Visual Studio 2022 / VS Code

### Quick Start
```bash
# Start Cosmos DB Emulator
# Run API (Terminal 1)
cd Demo.API && dotnet run --urls https://localhost:7001

# Run Web (Terminal 2)  
cd Demo.Web && dotnet run --urls https://localhost:7000
```

### Configuration
```json
// Demo.API/appsettings.Development.json
{
  "Cosmos": {
    "Endpoint": "https://localhost:8081/",
    "Key": "emulator-key",
    "DatabaseName": "DemoDatabase"
  }
}

// Demo.Web/appsettings.Development.json
{
  "ApiBaseUrl": "https://localhost:7001"
}
```

## 📊 Azure DevOps Setup

### Required Variables
| Variable | Description | Type |
|----------|-------------|------|
| `azureServiceConnection` | Service connection name | Variable |
| `apiAppServiceName` | API app service name | Variable |
| `webAppServiceName` | Web app service name | Variable | 
| `cosmosEndpoint` | Cosmos DB endpoint URL | Variable |
| `cosmosKey` | Cosmos DB access key | Secret |

### Resource Provisioning
```powershell
# Create Azure resources
.\deploy-azure-resources.ps1 -SubscriptionId "sub-id" -ResourceGroupName "rg-name" -Location "East US" -EnvironmentPrefix "prod"
```

## 🏆 Certification-Relevant Features

### **AZ-204 (Azure Developer)**
- ✅ App Service deployment and configuration
- ✅ Cosmos DB integration and partitioning
- ✅ Azure DevOps CI/CD implementation
- ✅ Application monitoring and logging

### **AZ-400 (DevOps Engineer)**  
- ✅ Multi-stage YAML pipelines
- ✅ Infrastructure as Code (PowerShell)
- ✅ Environment-specific deployments
- ✅ Automated testing integration points

### **Modern Development Practices**
- ✅ Microservices architecture
- ✅ Global exception handling
- ✅ Structured logging and monitoring  
- ✅ Security best practices
- ✅ Performance optimization patterns

---

**Tech Stack**: .NET 8, ASP.NET Core, Azure Cosmos DB, Azure App Service, Azure DevOps, Bootstrap, Swagger/OpenAPI