# Release notes for Menes v6.

## v6.0.0

This release marks a significant upgrade to the Menes framework, including updates to the .NET version and testing infrastructure, along with various dependency updates that occurred since v5.0.3.

### Major Changes

*   **Upgrade to .NET 8.0 and Migration to Reqnroll:** The project has been upgraded to target .NET 8.0. Additionally, the BDD testing framework has been migrated from SpecFlow to Reqnroll.

### Notable Dependency Updates (since v5.0.3)

*   **Corvus.UriTemplates:**
    *   Bumped from `1.1.0` to `1.2.2` in `/Solutions`.
*   **Corvus.Monitoring.Instrumentation.Abstractions:** Bumped in `/Solutions`. 
*   **Corvus.Extensions:** Bumped from `1.1.10` to `1.1.11` in `/Solutions`. 
*   **Microsoft.Azure.WebJobs:** Bumped from `3.0.36` to `3.0.37` in `/Solutions`.
*   **Endjin.RecommendedPractices.Build:**
    *   Updated from `1.0.0` to `1.4.0` in [`build.ps1`](build.ps1:0). ([#365](https://github.com/endjin/Menes/pull/365))
*   **Endjin.RecommendedPractices.GitHub:**
    *   Bumped in `/Solutions`. ([#340](https://github.com/endjin/Menes/pull/340))
    *   Updated in `/Solutions`. ([#364](https://github.com/endjin/Menes/pull/364))
    *   Updated projects with dependencies. ([#378](https://github.com/endjin/Menes/pull/378))
    *   Bumped in `/Solutions`. ([#386](https://github.com/endjin/Menes/pull/386))
*   **Endjin.PRAutoflow:** Bumped from `0.0.0` to `0.1.0` in [`.github/workflows`](.github/workflows:0). ([#352](https://github.com/endjin/Menes/pull/352))

### Build System and Tooling Updates (since v5.0.3)

*   Migrate to Zero Failed for Build.
*   General maintenance commits for dependency updates and build process refinements. 