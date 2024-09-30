using Model.Entities;

namespace Model.Dtos
{
    public record InformacoesNutricionaisDto
    (
        int Calorias,
        decimal Proteinas,
        decimal Carboidratos,
        decimal Fibras,
        decimal Gorduras
    )
    {
        public static InformacoesNutricionaisDto FromInformacoesNutricionais(InformacoesNutricionais informacoesNutricionais)
        {
            if(informacoesNutricionais == null)
            {
                return InformacoesNutricionaisDto.Empty();
            }

            return new InformacoesNutricionaisDto(
                Calorias: informacoesNutricionais.Calorias,
                Proteinas: informacoesNutricionais.Proteinas,
                Carboidratos: informacoesNutricionais.Carboidratos,
                Fibras: informacoesNutricionais.Fibras,
                Gorduras: informacoesNutricionais.Gorduras
            );
        }

        public static InformacoesNutricionaisDto Empty()
        {
            return new InformacoesNutricionaisDto(
                Calorias: 0,
                Proteinas: 0,
                Carboidratos: 0,
                Fibras: 0,
                Gorduras: 0
            );
        }
    }
}
