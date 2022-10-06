﻿using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemfilehandle">FileSystemFileHandle browser specs</see>
/// </summary>
public class FileSystemFileHandle : FileSystemHandle
{
    public static new async Task<FileSystemFileHandle> CreateAsync(IJSObjectReference jSReference, IJSRuntime jSRuntime)
    {
        IJSInProcessObjectReference helper = await jSRuntime.GetHelperAsync();
        return new FileSystemFileHandle(jSReference, helper);
    }

    internal FileSystemFileHandle(IJSObjectReference jSReference, IJSInProcessObjectReference helper) : base(jSReference, helper) { }

    public async Task<File> GetFileAsync()
    {
        IJSObjectReference? jSFile = await JSReference.InvokeAsync<IJSObjectReference>("getFile");
        return new File(jSFile, helper);
    }

    public async Task<FileSystemWritableFileStream> CreateWritableAsync(FileSystemCreateWritableOptions? fileSystemCreateWritableOptions = null)
    {
        IJSObjectReference? jSFileSystemWritableFileStream = await JSReference.InvokeAsync<IJSObjectReference>("createWritable", fileSystemCreateWritableOptions);
        return new FileSystemWritableFileStream(jSFileSystemWritableFileStream, helper);
    }
}
