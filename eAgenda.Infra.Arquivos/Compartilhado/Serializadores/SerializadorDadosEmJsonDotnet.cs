using Newtonsoft.Json;
using System;
using System.IO;

namespace Testes_da_Mariana.Infra.Arquivos.Compartilhado.Serializadores
{
    public class SerializadorDadosEmJsonDotnet : ISerializador
    {
        private string arquivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\dados.json";

        public DataContext CarregarDadosDoArquivo()
        {
            if (File.Exists(arquivo) == false)
                return new DataContext();

            string arquivoJson = File.ReadAllText(arquivo);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;
            settings.PreserveReferencesHandling = PreserveReferencesHandling.All;

            var x = JsonConvert.DeserializeObject<DataContext>(arquivoJson, settings);

            return x;
        }

        public void GravarDadosEmArquivo(DataContext dados)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;
            settings.PreserveReferencesHandling = PreserveReferencesHandling.All;

            string arquivoJson = JsonConvert.SerializeObject(dados, settings);

            File.WriteAllText(arquivo, arquivoJson);
        }
    }
}
