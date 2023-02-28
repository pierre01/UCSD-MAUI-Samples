using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiMedia.ViewModels;

public partial class MusicPlayerPageViewModel :ObservableObject, IQueryAttributable, IDisposable
{
	readonly IAudioManager audioManager;
	readonly IDispatcher dispatcher;
	IAudioPlayer audioPlayer;
	TimeSpan animationProgress;
	MusicItemViewModel musicItemViewModel;
	bool isPositionChangeSystemDriven;
	bool isDisposed;

	public MusicPlayerPageViewModel(
		IAudioManager audioManager,
		IDispatcher dispatcher)
	{
		this.audioManager = audioManager;
		this.dispatcher = dispatcher;

	}

	public async void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		//if (query.TryGetValue(Routes.MusicPlayer.Arguments.Music, out object musicObject) &&
		//	musicObject is MusicItemViewModel musicItem)
		//{
		//	MusicItemViewModel = musicItem;

		//	audioPlayer = audioManager.CreatePlayer(
		//		await FileSystem.OpenAppPackageFileAsync(musicItem.Filename));

		//	OnPropertyChanged(nameof(HasAudioSource));
		//	OnPropertyChanged(nameof(Duration));
		//	OnPropertyChanged(nameof(CanSetSpeed));
		//	OnPropertyChanged(nameof(MinimumSpeed));
		//	OnPropertyChanged(nameof(MaximumSpeed));
		//}
	}

	public double CurrentPosition
	{
		get => audioPlayer?.CurrentPosition ?? 0;
		set
		{
			if (audioPlayer is not null &&
				audioPlayer.CanSeek &&
				isPositionChangeSystemDriven is false)
			{
				audioPlayer.Seek(value);
			}
		}
	}

	public double Duration => audioPlayer?.Duration ?? 1;

	public MusicItemViewModel MusicItemViewModel
	{
		get => musicItemViewModel;
		set
		{
			musicItemViewModel = value;
            OnPropertyChanged();
		}
	}

	public bool HasAudioSource => audioPlayer is not null;

	public bool IsPlaying => audioPlayer?.IsPlaying ?? false;

	public TimeSpan AnimationProgress
	{
		get => animationProgress;
		set
		{
			animationProgress = value;
            OnPropertyChanged();
		}
	}

	public double Volume
	{
		get => audioPlayer?.Volume ?? 1;
		set
		{
			if (audioPlayer != null)
			{
				audioPlayer.Volume = value;
			}
		}
	}

	public double Balance
	{
		get => audioPlayer?.Balance ?? 0;
		set
		{
			if (audioPlayer != null)
			{
				audioPlayer.Balance = value;
			}
		}
	}

	public bool CanSetSpeed => audioPlayer?.CanSetSpeed ?? false;

	public double Speed
	{
		get => audioPlayer?.Speed ?? 1;
		set
		{
			try
			{
				if (audioPlayer?.CanSetSpeed ?? false)
				{
					audioPlayer.Speed = Math.Round(value, 1, MidpointRounding.AwayFromZero);
                    OnPropertyChanged();
				}
			}
			catch (Exception ex)
			{
				App.Current.MainPage.DisplayAlert("Speed", ex.Message, "OK");
			}
		}
	}

	public double MinimumSpeed => audioPlayer?.MinimumSpeed ?? 1;
	public double MaximumSpeed => audioPlayer?.MaximumSpeed ?? 1;

	public bool Loop
	{
		get => audioPlayer?.Loop ?? false;
		set
		{
			audioPlayer.Loop = value;
		}
	}

	[RelayCommand]
	void Play()
	{
		audioPlayer.Play();

		UpdatePlaybackPosition();
        OnPropertyChanged(nameof(IsPlaying));
	}

	[RelayCommand]
	void Pause()
	{
		if (audioPlayer.IsPlaying)
		{
			audioPlayer.Pause();
		}
		else
		{
			audioPlayer.Play();
		}

		UpdatePlaybackPosition();
        OnPropertyChanged(nameof(IsPlaying));
	}

	[RelayCommand]
	void Stop()
	{
		if (audioPlayer.IsPlaying)
		{
			audioPlayer.Stop();

			AnimationProgress = TimeSpan.Zero;

            OnPropertyChanged(nameof(IsPlaying));
		}
	}

	void UpdatePlaybackPosition()
	{
		if (audioPlayer?.IsPlaying is false)
		{
			return;
		}

		dispatcher.DispatchDelayed(
			TimeSpan.FromMilliseconds(16),
			() =>
			{
				Console.WriteLine($"{CurrentPosition} with duration of {Duration}");

				isPositionChangeSystemDriven = true;

                OnPropertyChanged(nameof(CurrentPosition));

				isPositionChangeSystemDriven = false;

				UpdatePlaybackPosition();
			});
	}

	public void TidyUp()
	{
		audioPlayer?.Dispose();
		audioPlayer = null;
	}

	~MusicPlayerPageViewModel()
	{
		Dispose(false);
	}

	public void Dispose()
	{
		Dispose(true);

		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (isDisposed)
		{
			return;
		}

		if (disposing)
		{
			TidyUp();
		}

		isDisposed = true;
	}
}