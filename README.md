                                                                                               
<p align='center'>
    <img width=192" src="https://raw.githubusercontent.com/8T4/mas-unity/main/docs/imgs/logo.png" />
    <br/>It is a dotnet framework that helps in the development of MAS (Multi-agent systems) applied to integrative business information systems (IBIS). MAS Unity will assist in the construction, deployment and monitoring of a cluster of autonomous agents.
    <br/>
    <br/>
    <a href='https://github.com/8T4/mas-unity/actions/workflows/dotnet.yml'><img src="https://github.com/8T4/mas-unity/actions/workflows/dotnet.yml/badge.svg"></a>
    <a href='https://github.com/8T4/gwtdo/actions/workflows/codeql-analysis.yml'><img src="https://github.com/8T4/gwtdo/actions/workflows/codeql-analysis.yml/badge.svg"></a>
    <a href='https://www.codacy.com/gh/8T4/gwtdo/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=8T4/gwtdo&amp;utm_campaign=Badge_Grade'> <img src="https://app.codacy.com/project/badge/Grade/51e1962835f24f65a3813d078061a9ef"></a>
</p>

### Instalation
This package is available through [Nuget Packages](https://www.nuget.org/packages?q=masunity).

| Package |  Description | Version | Downloads |
| ------- | ----- | ----- | ----- |
| `MasUnity` | provides structures and services to performs agent tasks | [![NuGet](https://img.shields.io/nuget/v/masunity.svg)](https://nuget.org/packages/masunity) | [![Nuget](https://img.shields.io/nuget/dt/masunity.svg)](https://nuget.org/packages/masunity) |
| `MasUnity.HostedService` | provides an execution environment to agent | [![NuGet](https://img.shields.io/nuget/v/MasUnity.HostedService.svg)](https://nuget.org/packages/MasUnity.HostedService) | [![Nuget](https://img.shields.io/nuget/dt/MasUnity.HostedService.svg)](https://nuget.org/packages/MasUnity.HostedService) |
| `MasUnity.HealthCheck` | provides a monitoring environment to agent | [![NuGet](https://img.shields.io/nuget/v/MasUnity.HealthCheck.svg)](https://nuget.org/packages/MasUnity.HealthCheck) | [![Nuget](https://img.shields.io/nuget/dt/MasUnity.HealthCheck.svg)](https://nuget.org/packages/MasUnity.HealthCheck) |
                 

                                                                                               

# Multi-agent systems (MAS)

Multi-agent systems are gradually becoming a new paradigm for developing distributed computing systems. This paradigm provides an appropriate architecture for the design and implementation of integrative business information systems as it addresses adequately the crucial requirements of coordination which, as discussed above, is central to the IBIS paradigm [1].

# MAS Unity Architecture

MAS Unity (MU) provides structures to build applications based on DAI (distributed artificial intelligence) solutions. With MU you can build a cluster of autonomous agents. Agents are the fundamental concept in the MAS paradigm. There are multiple agents in a multi-agent system. However, no agent possesses the knowledge or the capabilities to understand and solve the entire problem.

<p align='center'>
    <img src="https://raw.githubusercontent.com/8T4/mas-unity/main/docs/imgs/components.png" />
  <br/><small>Figure 1. MAS Unity Architecture </small>
</p> 
                                                                                            
How shown in Figure 1, MU Architecture can be divided into three distinct layers: Decision Layer, Application Layer, and Host Layer. the Decision Layer provides structures and services to performs agent tasks; the Application Layer contains de domain scope used by agents; the Host Layer provides an execution and monitoring environment.

# How to use

# References

1. Kishore, Rajiv / Zhang, Hong / Ramesh, Ram  
**Enterprise integration using the agent paradigm: foundations of multi-agent-based integrative business information systems**   
2006-11  
Decision Support Systems, Vol. 42  
p. 48-78






