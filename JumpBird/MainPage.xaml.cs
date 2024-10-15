namespace JumpBird;

public partial class MainPage : ContentPage
{


	const int TempoEntreFrames = 25;
	const int Gravidade = 3;
	double LarguraJanela;
	double AlturaJanela;
	int velocidade = 20;
	bool estaMorto = true;
	public MainPage()
	{
		InitializeComponent();
	}

  public async void Desenha()
  {
	while (!estaMorto)
	{
		AplicaGravidade();
		GerenciaCanos();
		if (VerificaColisao())
		{
			estaMorto=true;
			GameOverFrame.IsVisible=true;
			break;
		}
		await Task.Delay(TempoEntreFrames);
	}
  }
	void AplicaGravidade()
	{
		Passaro.TranslationY += Gravidade;
	
	}

	
	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		LarguraJanela = w;
		AlturaJanela = h;
		
	}
	void GerenciaCanos()
	{
		imgCanoCima.TranslationX -= velocidade;
		imgCanoBaixo.TranslationX -= velocidade;

		if (imgCanoBaixo.TranslationX <- LarguraJanela)
		{
			imgCanoBaixo.TranslationX = 0;
			imgCanoCima.TranslationX = 0;
		}
	}


	void Ei(object s, TappedEventArgs e)
	{
		GameOverFrame.IsVisible = false;
		estaMorto = false;
		Inicializar();
		Desenha();
	}
	void Inicializar()
	{
		Passaro.TranslationY = 0;
	}
	bool VerificaColisaoTeto()
	{
		var minY=-AlturaJanela/2;
		if (Passaro.TranslationY <= minY)
		return true;
		else
		return false;
	}
	bool VerificaColisaoChao()
	{
		var maxY=AlturaJanela/2;
		if(Passaro.TranslationY >= maxY)
		return true;
		else 
		return false;
	}

	bool VerificaColisao()
	{
		if(! estaMorto)
		{
			if(VerificaColisaoTeto() ||
				VerificaColisaoChao())
		{
			return true;
		}
		}
		return false;
	}

}

