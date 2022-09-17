using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulasCSharp.Exceções
{
    public class Conta
    {
        double Saldo { get; set; }
        double ChequeEspecial { get; set; }
        bool LiberadoChequeEspecial { get; set; }

        public Conta(double saldo, double chequeEspecial, bool liberadoChequeEspecial)
        {
            Saldo = saldo;
            ChequeEspecial = chequeEspecial;
            LiberadoChequeEspecial = liberadoChequeEspecial;
        }

        private void DescontarDinheiro(double valorSaque)
        {
            if (Saldo >= valorSaque)
            {
                Saldo -= valorSaque;
            }
            else
            {
                if (LiberadoChequeEspecial)
                {
                    if ((ChequeEspecial + Saldo) >= valorSaque)
                    {
                        Saldo -= valorSaque;
                    }
                    else
                    {
                        // Para a execução do método -> A partir do throw nada abaixo é executado
                        throw new Exception("A conta possui cheque especial, porém o valor é muito alto.");
                    }
                }
                else
                {
                    // Para a execução do método -> A partir do throw nada abaixo é executado
                    throw new Exception("O valor é muito alto e essa conta não possui cheque especial.");
                }
            }
        }

        public void SacarGrana(double valorSaque)
        {
            try
            {
                DescontarDinheiro(valorSaque);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao realizar saque. Mensagem: {erro.Message}");
            }
        }

        public void ComprarDebito(double valorSaque)
        {
            try
            {
                DescontarDinheiro(valorSaque);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao realizar compra. Mensagem: {erro.Message}");
            }
        }
    }

    public enum TipoOperacao
    {
        Saque,
        Compra
    }

    internal class TratandoExceptions
    {
        public static void RealizarOperacao(Conta conta, double valor, TipoOperacao tipo)
        {
            try
            {
                switch (tipo)
                {
                    case TipoOperacao.Saque:
                        conta.SacarGrana(valor);
                        break;
                    case TipoOperacao.Compra:
                        conta.ComprarDebito(valor);
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Não foi possível executar a operação. Erro: {erro.Message}");
            }
        }
    }
}
