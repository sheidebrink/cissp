using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CisspTrainingApp.Services;

namespace CisspTrainingApp.Pages
{
    public class AcronymsModel : PageModel
    {
        public Dictionary<string, string> Acronyms { get; set; } = new()
        {
            {"AAA", "Authentication, Authorization, and Accounting"},
            {"ABAC", "Attribute-Based Access Control"},
            {"ACL", "Access Control List"},
            {"AES", "Advanced Encryption Standard"},
            {"APT", "Advanced Persistent Threat"},
            {"BCP", "Business Continuity Planning"},
            {"BIA", "Business Impact Analysis"},
            {"CA", "Certificate Authority"},
            {"CCTV", "Closed-Circuit Television"},
            {"CIA", "Confidentiality, Integrity, and Availability"},
            {"CIRT", "Computer Incident Response Team"},
            {"CISSP", "Certified Information Systems Security Professional"},
            {"COOP", "Continuity of Operations Plan"},
            {"COTS", "Commercial Off-The-Shelf"},
            {"CRL", "Certificate Revocation List"},
            {"CSF", "Cybersecurity Framework"},
            {"DAC", "Discretionary Access Control"},
            {"DDoS", "Distributed Denial of Service"},
            {"DES", "Data Encryption Standard"},
            {"DHCP", "Dynamic Host Configuration Protocol"},
            {"DMZ", "Demilitarized Zone"},
            {"DNS", "Domain Name System"},
            {"DoS", "Denial of Service"},
            {"DRP", "Disaster Recovery Plan"},
            {"DSS", "Digital Signature Standard"},
            {"EAL", "Evaluation Assurance Level"},
            {"ECC", "Elliptic Curve Cryptography"},
            {"FIPS", "Federal Information Processing Standards"},
            {"FTP", "File Transfer Protocol"},
            {"GDPR", "General Data Protection Regulation"},
            {"HIPAA", "Health Insurance Portability and Accountability Act"},
            {"HIDS", "Host-based Intrusion Detection System"},
            {"HIPS", "Host-based Intrusion Prevention System"},
            {"HMAC", "Hash-based Message Authentication Code"},
            {"HTTP", "Hypertext Transfer Protocol"},
            {"HTTPS", "Hypertext Transfer Protocol Secure"},
            {"IaaS", "Infrastructure as a Service"},
            {"IAM", "Identity and Access Management"},
            {"ICMP", "Internet Control Message Protocol"},
            {"IDS", "Intrusion Detection System"},
            {"IEEE", "Institute of Electrical and Electronics Engineers"},
            {"IPSEC", "Internet Protocol Security"},
            {"IPS", "Intrusion Prevention System"},
            {"ISO", "International Organization for Standardization"},
            {"ITIL", "Information Technology Infrastructure Library"},
            {"IV", "Initialization Vector"},
            {"KDC", "Key Distribution Center"},
            {"LDAP", "Lightweight Directory Access Protocol"},
            {"MAC", "Mandatory Access Control / Message Authentication Code"},
            {"MFA", "Multi-Factor Authentication"},
            {"MTBF", "Mean Time Between Failures"},
            {"MTTR", "Mean Time To Recovery"},
            {"NAC", "Network Access Control"},
            {"NAT", "Network Address Translation"},
            {"NIDS", "Network-based Intrusion Detection System"},
            {"NIPS", "Network-based Intrusion Prevention System"},
            {"NIST", "National Institute of Standards and Technology"},
            {"OCSP", "Online Certificate Status Protocol"},
            {"OSI", "Open Systems Interconnection"},
            {"OWASP", "Open Web Application Security Project"},
            {"PaaS", "Platform as a Service"},
            {"PAM", "Privileged Access Management"},
            {"PCI DSS", "Payment Card Industry Data Security Standard"},
            {"PGP", "Pretty Good Privacy"},
            {"PHI", "Protected Health Information"},
            {"PII", "Personally Identifiable Information"},
            {"PKI", "Public Key Infrastructure"},
            {"RBAC", "Role-Based Access Control"},
            {"RFC", "Request for Comments"},
            {"RPC", "Remote Procedure Call"},
            {"RPO", "Recovery Point Objective"},
            {"RSA", "Rivest-Shamir-Adleman"},
            {"RTO", "Recovery Time Objective"},
            {"SaaS", "Software as a Service"},
            {"SAML", "Security Assertion Markup Language"},
            {"SDLC", "Software Development Life Cycle"},
            {"SHA", "Secure Hash Algorithm"},
            {"SIEM", "Security Information and Event Management"},
            {"SLA", "Service Level Agreement"},
            {"SMTP", "Simple Mail Transfer Protocol"},
            {"SNMP", "Simple Network Management Protocol"},
            {"SOA", "Service-Oriented Architecture"},
            {"SOAP", "Simple Object Access Protocol"},
            {"SOC", "Security Operations Center"},
            {"SOX", "Sarbanes-Oxley Act"},
            {"SQL", "Structured Query Language"},
            {"SSH", "Secure Shell"},
            {"SSL", "Secure Sockets Layer"},
            {"SSO", "Single Sign-On"},
            {"TCP", "Transmission Control Protocol"},
            {"TLS", "Transport Layer Security"},
            {"TPM", "Trusted Platform Module"},
            {"UDP", "User Datagram Protocol"},
            {"UPS", "Uninterruptible Power Supply"},
            {"URL", "Uniform Resource Locator"},
            {"VPN", "Virtual Private Network"},
            {"WAF", "Web Application Firewall"},
            {"WPA", "Wi-Fi Protected Access"},
            {"XML", "Extensible Markup Language"}
        };

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostGetAcronymDetails(string acronym, string description)
        {
            try
            {
                var novaService = new NovaService();
                var details = await novaService.GetAcronymDetails(acronym, description);
                return new JsonResult(new { details });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}