using Gama.Infra;
using Gama.Repository.Models;
using Gama.Repository.Repositories;
using System;
using System.Threading.Tasks;

namespace Gama.ApplicationService
{
    public class KeyValuesApplicationService : IDisposable
    {
        private KeyValuesRepository _keyValuesRepository = new KeyValuesRepository();

        public void Dispose()
        {
            _keyValuesRepository.Dispose();
        }

        public async Task SaveKeyValueAndSendEmail(KeyValueModels model)
        {
            var _emailService = new EmailService();
            _emailService.SendMail();
            await _keyValuesRepository.Insert(model);
        }

    }
}
