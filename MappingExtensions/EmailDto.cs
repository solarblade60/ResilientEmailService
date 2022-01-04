using RupaHealth.Models.Dtos;
using RupaHealth.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RupaHealth.MappingExtensions
{
    public static class EmailDtoExtension
    {
        public static EmailDto ToEmailDto(this EmailParams d)
        {
            return (d == null)
                ? new EmailDto()
                : new EmailDto
                {
                    ToEmailAddress = d.To,
                    ToName = d.To_Name ?? "",
                    FromEmailAddress = d.From,
                    FromName = d.From_Name ?? "",
                    Subject = d.Subject ?? "",
                    Body = d.Body ?? ""
                };
        }

    }
}
